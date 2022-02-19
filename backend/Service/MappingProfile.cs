using AutoMapper;
using Core.DTOs;
using Core.Entities;

namespace Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Guarantor, GuarantorDTO>();
            CreateMap<GuarantorDTO, Guarantor>();

            CreateMap<HeadOfSmc, HeadOfSmcDTO>();
            CreateMap<HeadOfSmcDTO, HeadOfSmc>();

            CreateMap<KnowledgeBranch, KnowledgeBranchDTO>();
            CreateMap<KnowledgeBranchDTO, KnowledgeBranch>();

            CreateMap<Specialty, SpecialtyDTO>();
            CreateMap<SpecialtyDTO, Specialty>();

            CreateMap<Subject, SubjectDTO>();
            CreateMap<SubjectDTO, Subject>();

            CreateMap<Syllabus, SyllabusDTO>();
            CreateMap<SyllabusDTO, Syllabus>();

            CreateMap<Teacher, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();

            CreateMap<TeacherLoad, TeacherLoadDTO>();
            CreateMap<TeacherLoadDTO, TeacherLoad>();
            
            CreateMap<Template, TemplateDTO>();
            CreateMap<TemplateDTO, Template>();
        }
    }
}
