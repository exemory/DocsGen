using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        public TemplateRepository(UniversityContext context) : base(context)
        {
        }
    }
}
