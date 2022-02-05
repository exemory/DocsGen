using Core.Entities;
using Core.Repositories;

namespace Infrastructure.Repositories
{
    public class GuarantorRepository : Repository<Guarantor>, IGuarantorRepository
    {
        public GuarantorRepository(UniversityContext context) : base(context)
        {
        }
    }
}
