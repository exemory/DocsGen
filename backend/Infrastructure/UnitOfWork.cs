using Core;
using Core.Entities;
using Core.Entities.Base;
using Core.Exceptions;
using Core.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext _context;

        private readonly Dictionary<Type, dynamic> _repositories = new();

        public ITeacherRepository Teachers => _repositories[typeof(Specialty)];

        public IHeadOfSmcRepository HeadsOfSmc => _repositories[typeof(Specialty)];

        public IGuarantorRepository Guarantors => _repositories[typeof(Specialty)];

        public IKnowledgeBranchRepository KnowledgeBranches => _repositories[typeof(Specialty)];

        public ISpecialtyRepository Specialties => _repositories[typeof(Specialty)];

        public ISubjectRepository Subjects => _repositories[typeof(Specialty)];

        public ISyllabusRepository Syllabuses => _repositories[typeof(Specialty)];

        public ITeacherLoadRepository TeacherLoads => _repositories[typeof(Specialty)];

        public ITemplateRepository Templates => _repositories[typeof(Template)];

        public UnitOfWork(UniversityContext context)
        {
            _context = context;

            _repositories[typeof(Teacher)] = new TeacherRepository(_context);
            _repositories[typeof(HeadOfSmc)] = new HeadOfSmcRepository(_context);
            _repositories[typeof(Guarantor)] = new GuarantorRepository(_context);
            _repositories[typeof(KnowledgeBranch)] = new KnowledgeBranchRepository(_context);
            _repositories[typeof(Specialty)] = new SpecialtyRepository(_context);
            _repositories[typeof(Subject)] = new SubjectRepository(_context);
            _repositories[typeof(Syllabus)] = new SyllabusRepository(_context);
            _repositories[typeof(TeacherLoad)] = new TeacherLoadRepository(_context);
            _repositories[typeof(Template)] = new TemplateRepository(_context);
        }

        public IRepository<TEntity> Repository<TEntity>()
            where TEntity : Entity, new()
        {
            var entityType = typeof(TEntity);

            return _repositories[entityType];
        }

        public async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (ex.Entries.Count > 0)
                {
                    throw new EntityNotFoundException("Entity not found.", ex, ex.Entries[0].Entity.GetType());
                }

                throw;
            }
            catch (DbUpdateException ex)
            {
                if (ex.Entries.Count > 0 && ex.InnerException is DbException dbEx)
                {
                    switch (dbEx.SqlState)
                    {
                        case "23503":
                            throw new EntityConflictException("Insert or update operation violates foreign key constraint.", ex, ex.Entries[0].Entity.GetType());
                        case "23505":
                            throw new EntityConflictException("Duplicate key value violates unique constraint.", ex, ex.Entries[0].Entity.GetType());
                    }
                }

                throw;
            }
        }

        public void Rollback()
        {
            _context.ChangeTracker.Clear();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}