using Core.Entities;

namespace Core.Repositories
{
    public interface ITemplateRepository : IRepository<Template>
    {
        public Task DeleteOutdated(TimeSpan olderThan);
    }
}
