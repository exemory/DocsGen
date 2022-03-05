using System.IO.Compression;
using Core;
using Core.DTOs;
using Core.Entities;
using Core.Entities.Base;
using Core.Enums;
using Core.Exceptions;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Stream> GenerateCurriculaArchive(GenerateCurriculaDTO data)
        {
            var files = await GenerateCurricula(data);

            var archiveStream = new MemoryStream();

            using (var archive = new ZipArchive(archiveStream, ZipArchiveMode.Create, true))
            {
                foreach (var (fileName, content) in files)
                {
                    await using (content)
                    {
                        var zipFile = archive.CreateEntry(fileName, CompressionLevel.Fastest);

                        await using var zipFileStream = zipFile.Open();
                        content.Position = 0;
                        await content.CopyToAsync(zipFileStream);
                    }
                }
            }

            archiveStream.Position = 0;
            return archiveStream;
        }

        public async Task<IEnumerable<(string fileName, Stream content)>> GenerateCurricula(GenerateCurriculaDTO data)
        {
            Template template;
            try
            {
                template = await _unitOfWork.Templates.GetById(data.TemplateId);
            }
            catch (EntityNotFoundException e)
            {
                throw new TemplateException($"Template with id '{data.TemplateId}' not found", e);
            }

            var query = _unitOfWork.TeacherLoads
                .Get()
                .Include(load => load.Teacher)
                .Include(load => load.Subject)
                .Include(load => load.Specialty)
                .ThenInclude(spec => spec.KnowledgeBranch)
                .Include(load => load.Specialty)
                .ThenInclude(spec => spec.HeadOfSmc)
                .Include(load => load.Specialty)
                .ThenInclude(spec => spec.Guarantor)
                .Include(load => load.Syllabus)
                .Where(load => load.Type == TeacherLoadType.Lecture)
                .AsNoTracking();

            var loads = await query
                .Where(t => data.TeacherIds.Contains(t.Teacher.Id))
                .ToListAsync();

            var docs = loads
                .AsParallel()
                .Select(load =>
                {
                    var contentLength = template.Content.Length;
                    var templateContent = new byte[contentLength];
                    Array.Copy(template.Content, templateContent, contentLength);
                    
                    var contentStream = new MemoryStream(templateContent);
                    GenerateCurriculum(contentStream, load, out var fileName);

                    return (fileName, (Stream)contentStream);
                })
                .ToList();

            return docs;
        }

        private static void GenerateCurriculum(Stream template, TeacherLoad load, out string fileName)
        {
            using WordTemplate wordTemplate = new(template);

            Dictionary<string, object?> replacements = new()
            {
                {"{Освітній_рівень}", load.Year <= 4 ? "Бакалавр" : "Магістр"},
                {"{Назва_дисципліни}", load.Subject.Name},
                {"{Шифр_спеціальності}", load.Specialty.Code},
                {"{ШС}", load.Specialty.Code},
                {"{Назва_спеціальності}", load.Specialty.Name},
                {"{Прізвище_І_Б_викладача}", GetShortName(load.Teacher, "\u00A0")},
                {"{Науковий_ступінь_викладача}", load.Teacher.AcademicDegree},
                {"{Звання_викладача}", load.Teacher.AcademicRank},
                {"{Шифр_галузі}", load.Specialty.KnowledgeBranch.Code},
                {"{ШГ}", load.Specialty.KnowledgeBranch.Code},
                {"{Назва_галузі}", load.Specialty.KnowledgeBranch.Name},
                {"{Прізвище_І_Б_голови_НМК}", GetShortName(load.Specialty.HeadOfSmc, "\u00A0")},
                {"{Прізвище_І_Б_гаранта}", GetShortName(load.Specialty.Guarantor, "\u00A0")},
                {"{КРД}", load.Syllabus.Credits},
                {"{В}", load.Syllabus.TotalHours},
                {"{АР}", load.Syllabus.ClassroomHours},
                {"{Л}", load.Syllabus.LectureHours},
                {"{ЛР}", load.Syllabus.LabHours},
                {"{ПЗ}", load.Syllabus.PracticalHours},
                {"{КП}", load.Syllabus.CourseProjects},
                {"{КР}", load.Syllabus.CourseWork},
                {"{РГР}", load.Syllabus.RGR},
                {"{Р}", load.Syllabus.R},
                {"{ФК}", load.Syllabus.FormOfControl},
                {"{С}", load.Syllabus.Semester}
            };

            var teacherAcademicDegreeRank = $"{GetShortName(load.Teacher, "\u00A0")}, ";
            if (load.Teacher.AcademicDegree != null)
            {
                teacherAcademicDegreeRank += $"{load.Teacher.AcademicDegree.ToLower()}, ";
            }

            teacherAcademicDegreeRank += load.Teacher.AcademicRank.ToLower();

            replacements.Add("{Викладач_науковий_ступінь_звання}", teacherAcademicDegreeRank);

            wordTemplate.Fill(replacements);

            fileName =
                $"{GetShortName(load.Teacher, "_")}_" +
                $"{load.Year}_курс_" +
                $"{load.Specialty.Code}_спец_" +
                $"{load.Subject.Name.Replace(' ', '_')}.docx";
            fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
        }

        private static string GetShortName(PersonEntity person, string separator) =>
            $"{person.Surname}{separator}{person.Name[0]}.{separator}{person.Patronymic[0]}.";
    }
}