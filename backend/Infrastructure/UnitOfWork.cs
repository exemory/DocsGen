using Core;
using Core.Entities;
using Core.Entities.Base;
using Core.Exceptions;
using Core.Repositories;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Core.Enums;

namespace Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly UniversityContext _context;

        private readonly Dictionary<Type, dynamic> _repositories = new();

        public IRepository<Teacher> Teachers => _repositories[typeof(Teacher)];

        public IRepository<HeadOfSmc> HeadsOfSmc => _repositories[typeof(HeadOfSmc)];

        public IRepository<Guarantor> Guarantors => _repositories[typeof(Guarantor)];

        public IRepository<KnowledgeBranch> KnowledgeBranches => _repositories[typeof(KnowledgeBranch)];

        public IRepository<Specialty> Specialties => _repositories[typeof(Specialty)];

        public IRepository<Subject> Subjects => _repositories[typeof(Subject)];

        public IRepository<Syllabus> Syllabuses => _repositories[typeof(Syllabus)];

        public IRepository<TeacherLoad> TeacherLoads => _repositories[typeof(TeacherLoad)];

        public IRepository<Template> Templates => _repositories[typeof(Template)];

        public UnitOfWork(UniversityContext context)
        {
            _context = context;

            _repositories[typeof(Teacher)] = new Repository<Teacher>(_context);
            _repositories[typeof(HeadOfSmc)] = new Repository<HeadOfSmc>(_context);
            _repositories[typeof(Guarantor)] = new Repository<Guarantor>(_context);
            _repositories[typeof(KnowledgeBranch)] = new Repository<KnowledgeBranch>(_context);
            _repositories[typeof(Specialty)] = new Repository<Specialty>(_context);
            _repositories[typeof(Subject)] = new Repository<Subject>(_context);
            _repositories[typeof(Syllabus)] = new Repository<Syllabus>(_context);
            _repositories[typeof(TeacherLoad)] = new Repository<TeacherLoad>(_context);
            _repositories[typeof(Template)] = new Repository<Template>(_context);
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