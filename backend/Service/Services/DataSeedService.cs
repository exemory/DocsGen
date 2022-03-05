using Core.Entities;
using Core.Enums;
using Core.Services;
using Infrastructure;

namespace Service.Services
{
    public class DataSeedService : IDataSeedService
    {
        private readonly UniversityContext _context;
        
        public DataSeedService(UniversityContext context)
        {
            _context = context;
        }

        public void SeedTestData()
        {
            Teacher[] teachers =
            {
                new Teacher { Name = "Олена", Surname = "Микитенко", Patronymic = "Іванівна", AcademicRank = "Доцент", Email = "olenahelena@ukr.net", Phone = "+380676502876"},
                new Teacher { Name = "Ірина", Surname = "Безкрай", Patronymic = "Анатоліївна", AcademicDegree = "д.т.н.", AcademicRank = "Професор", Email = "iragurina@gmail.com"},
                new Teacher { Name = "Василь", Surname = "Чапурний", Patronymic = "Віталійович", AcademicRank = "Доцент", Phone = "+380639359303"},
                new Teacher { Name = "Анна", Surname = "Травнева", Patronymic = "Максимівна", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "travanna434@mail.ua", Phone = "+380977317052"}
            };

            _context.Teachers.AddRange(teachers);

            HeadOfSmc[] heads =
            {
                new HeadOfSmc { Name = "Василь", Surname = "Чапурний", Patronymic = "Віталійович", AcademicDegree = "д.т.н.", AcademicRank = "Доцент", Phone = "+380639359303"},
                new HeadOfSmc { Name = "Георгій", Surname = "Гучний", Patronymic = "Володимирович", AcademicRank = "Доцент", Email = "gregorguchniy_34@gmail.com", Phone = "+380933279002"},
                new HeadOfSmc { Name = "Андрій", Surname = "Голуб", Patronymic = "Олегович", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "andreyka483@mail.com.com"},
                new HeadOfSmc { Name = "Тетяна", Surname = "Компанець", Patronymic = "Олександрівна", AcademicRank = "Доцент", Phone = "+380664763861"},
                new HeadOfSmc { Name = "Ірина", Surname = "Безкрай", Patronymic = "Анатоліївна", AcademicDegree = "д.т.н.", AcademicRank = "Професор", Email = "iragurina@gmail.com"},
                new HeadOfSmc { Name = "Дмитро", Surname = "Подоляк", Patronymic = "Ігорович", AcademicDegree = "д.т.н.", AcademicRank = "Доцент", Phone = "+380666208284"},
                new HeadOfSmc { Name = "Анна", Surname = "Травнева", Patronymic = "Максимівна", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "travanna434@mail.ua", Phone = "+380977317052"},
                new HeadOfSmc { Name = "Олександр", Surname = "Колонюк", Patronymic = "Степанович", AcademicRank = "Доцент", Email = "abracodabra@ukr.net", Phone = "+380677259076"},
                new HeadOfSmc { Name = "Олена", Surname = "Микитенко", Patronymic = "Іванівна", AcademicDegree = "к.т.н.", AcademicRank = "Професор", Email = "olenahelena@ukr.net", Phone = "+380676502876"},
                new HeadOfSmc { Name = "Юлія", Surname = "Хмарна", Patronymic = "Петрівна", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "ktdort234@gmail.com", Phone = "+380953957029"},
                new HeadOfSmc { Name = "Олена", Surname = "Незбарна", Patronymic = "Дмитрівна", AcademicRank = "Доцент", Email = "nezbr41@gmail.com"}
            };

            _context.HeadsOfSmc.AddRange(heads);

            Guarantor[] guarantors =
            {
                new Guarantor { Name = "Олександр", Surname = "Колонюк", Patronymic = "Степанович", AcademicRank = "Доцент", Email = "abracodabra@ukr.net", Phone = "+380677259076"},
                new Guarantor { Name = "Юлія", Surname = "Хмарна", Patronymic = "Петрівна", AcademicRank = "Доцент", Email = "ktdort234@gmail.com", Phone = "+380953957029"},
                new Guarantor { Name = "Олена", Surname = "Незбарна", Patronymic = "Дмитрівна", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "nezbr41@gmail.com"},
                new Guarantor { Name = "Дмитро", Surname = "Подоляк", Patronymic = "Ігорович", AcademicDegree = "д.т.н.", AcademicRank = "Професор", Phone = "+380666208284"},
                new Guarantor { Name = "Олена", Surname = "Микитенко", Patronymic = "Іванівна", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "olenahelena@ukr.net", Phone = "+380676502876"},
                new Guarantor { Name = "Ірина", Surname = "Безкрай", Patronymic = "Анатоліївна", AcademicRank = "Доцент", Email = "iragurina@gmail.com"},
                new Guarantor { Name = "Василь", Surname = "Чапурний", Patronymic = "Віталійович", AcademicDegree = "д.т.н.", AcademicRank = "Професор", Phone = "+380639359303"},
                new Guarantor { Name = "Анна", Surname = "Травнева", Patronymic = "Максимівна", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "travanna434@mail.ua", Phone = "+380977317052"},
                new Guarantor { Name = "Андрій", Surname = "Голуб", Patronymic = "Олегович", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "andreyka483@mail.com.com"},
                new Guarantor { Name = "Тетяна", Surname = "Компанець", Patronymic = "Олександрівна", AcademicRank = "Доцент", Phone = "+380664763861"},
                new Guarantor { Name = "Георгій", Surname = "Гучний", Patronymic = "Володимирович", AcademicDegree = "к.т.н.", AcademicRank = "Доцент", Email = "gregorguchniy_34@gmail.com", Phone = "+380933279002"}
            };

            _context.Guarantors.AddRange(guarantors);

            KnowledgeBranch[] kb =
            {
                new KnowledgeBranch { Code = "12", Name = "Інформаційні технології" },
                new KnowledgeBranch { Code = "15", Name = "Автоматизація та приладобудування" },
                new KnowledgeBranch { Code = "19", Name = "Архітектура та будівництво" }
            };

            _context.KnowledgeBranches.AddRange(kb);

            Specialty[] specs =
            {
                new Specialty { Code = "121", Name = "Інженерія програмного забезпечення", KnowledgeBranch = kb[0], HeadOfSmc = heads[1], Guarantor = guarantors[3] },
                new Specialty { Code = "122", Name = "Комп’ютерні науки та інформаційні технології", KnowledgeBranch = kb[0], HeadOfSmc = heads[5], Guarantor = guarantors[10] },
                new Specialty { Code = "123", Name = "Комп’ютерна інженерія", KnowledgeBranch = kb[0], HeadOfSmc = heads[1], Guarantor = guarantors[7] },
                new Specialty { Code = "125", Name = "Кібербезпека", KnowledgeBranch = kb[0], HeadOfSmc = heads[6], Guarantor = guarantors[4] },
                new Specialty { Code = "126", Name = "Інформаційні системи та технології", KnowledgeBranch = kb[0], HeadOfSmc = heads[2], Guarantor = guarantors[1] },

                new Specialty { Code = "151", Name = "Автоматизація та комп'ютерно-інтегровані технології", KnowledgeBranch = kb[1], HeadOfSmc = heads[4], Guarantor = guarantors[0] },
                new Specialty { Code = "152", Name = "Метрологія та інформаційно-вимірювальна техніка", KnowledgeBranch = kb[1], HeadOfSmc = heads[1], Guarantor = guarantors[2] },
                new Specialty { Code = "153", Name = "Мікро- та наносистемна техніка", KnowledgeBranch = kb[1], HeadOfSmc = heads[5], Guarantor = guarantors[8] },

                new Specialty { Code = "191", Name = "Архітектура та містобудування", KnowledgeBranch = kb[2], HeadOfSmc = heads[9], Guarantor = guarantors[6] },
                new Specialty { Code = "192", Name = "Будівництво та цивільна інженерія", KnowledgeBranch = kb[2], HeadOfSmc = heads[2], Guarantor = guarantors[5] },
                new Specialty { Code = "193", Name = "Геодезія та землеустрій", KnowledgeBranch = kb[2], HeadOfSmc = heads[3], Guarantor = guarantors[9] }
            };

            _context.Specialties.AddRange(specs);

            Subject[] subjects =
            {
                new Subject { Name = "Вища математика" },
                new Subject { Name = "Ергономіка інформаційних технологій" },
                new Subject { Name = "Об'єктно-орієнтоване програмування" },
                new Subject { Name = "Екологія" },
                new Subject { Name = "Комп'ютерна схемотехніка та електроніка" },
                new Subject { Name = "Теорія рядів дійсної та комплексної змінної" },
                new Subject { Name = "Історія філософії та філософської думки" }
            };

            _context.Subjects.AddRange(subjects);

            Syllabus[] syllabuses =
            {
                new Syllabus { Credits = "5", TotalHours = 150, ClassroomHours = 68, LectureHours = 34, PracticalHours = 34, RGR = 2, FormOfControl = "екз.", Semester = 3},
                new Syllabus { Credits = "3", TotalHours = 120, ClassroomHours = 70, LectureHours = 40, LabHours = 30, CourseProjects = 1, FormOfControl = "зал.", Semester = 6},
                new Syllabus { Credits = "6,6", TotalHours = 170, ClassroomHours = 56, LectureHours = 32, LabHours = 4, PracticalHours = 20, RGR = 1, FormOfControl = "зал.", Semester = 2},
                new Syllabus { Credits = "3,5", TotalHours = 90, ClassroomHours = 64, LectureHours = 38, PracticalHours = 26, R = 2, FormOfControl = "екз.", Semester = 8},
                new Syllabus { Credits = "4", TotalHours = 110, ClassroomHours = 72, LectureHours = 42, LabHours = 6, PracticalHours = 24, CourseWork = 1, FormOfControl = "зал.", Semester = 5},
                new Syllabus { Credits = "5,5", TotalHours = 140, ClassroomHours = 60, LectureHours = 34, PracticalHours = 26, CourseProjects = 1, FormOfControl = "екз.", Semester = 1}
            };

            _context.Syllabuses.AddRange(syllabuses);

            TeacherLoad[] loads =
            {
                new TeacherLoad { Type = TeacherLoadType.Practice, Year = 2, Teacher = teachers[2], Subject = subjects[3], Specialty = specs[10], Syllabus = syllabuses[2] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 6, Teacher = teachers[0], Subject = subjects[1], Specialty = specs[6], Syllabus = syllabuses[4] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 3, Teacher = teachers[2], Subject = subjects[2], Specialty = specs[3], Syllabus = syllabuses[1] },
                new TeacherLoad { Type = TeacherLoadType.Practice, Year = 4, Teacher = teachers[3], Subject = subjects[6], Specialty = specs[0], Syllabus = syllabuses[3] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 1, Teacher = teachers[1], Subject = subjects[4], Specialty = specs[8], Syllabus = syllabuses[3] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 3, Teacher = teachers[3], Subject = subjects[0], Specialty = specs[5], Syllabus = syllabuses[0] },
                new TeacherLoad { Type = TeacherLoadType.Practice, Year = 2, Teacher = teachers[0], Subject = subjects[3], Specialty = specs[7], Syllabus = syllabuses[4] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 5, Teacher = teachers[1], Subject = subjects[0], Specialty = specs[9], Syllabus = syllabuses[5] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 3, Teacher = teachers[3], Subject = subjects[5], Specialty = specs[4], Syllabus = syllabuses[3] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 2, Teacher = teachers[2], Subject = subjects[0], Specialty = specs[7], Syllabus = syllabuses[2] },
                new TeacherLoad { Type = TeacherLoadType.Practice, Year = 6, Teacher = teachers[1], Subject = subjects[5], Specialty = specs[6], Syllabus = syllabuses[5] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 6, Teacher = teachers[2], Subject = subjects[2], Specialty = specs[7], Syllabus = syllabuses[0] },
                new TeacherLoad { Type = TeacherLoadType.Practice, Year = 5, Teacher = teachers[1], Subject = subjects[1], Specialty = specs[7], Syllabus = syllabuses[1] },
                new TeacherLoad { Type = TeacherLoadType.Practice, Year = 4, Teacher = teachers[3], Subject = subjects[6], Specialty = specs[1], Syllabus = syllabuses[4] },
                new TeacherLoad { Type = TeacherLoadType.Lecture, Year = 5, Teacher = teachers[0], Subject = subjects[1], Specialty = specs[8], Syllabus = syllabuses[1] },
                new TeacherLoad { Type = TeacherLoadType.Practice, Year = 1, Teacher = teachers[1], Subject = subjects[4], Specialty = specs[10], Syllabus = syllabuses[0] }
            };

            _context.TeacherLoads.AddRange(loads);

            _context.SaveChanges();
        }
    }
}
