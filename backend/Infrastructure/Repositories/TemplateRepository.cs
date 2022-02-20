using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        public TemplateRepository(UniversityContext context) : base(context)
        {
        }
        
        public async Task DeleteOutdated(TimeSpan olderThan)
        {
            var currentDate = DateTime.UtcNow;

            var outdatedTemplates =  await _set
                .Where(t => currentDate - t.UploadDate > olderThan)
                .Select(t => new Template {Id = t.Id})
                .ToListAsync();

            _set.RemoveRange(outdatedTemplates);
        }
    }
}
