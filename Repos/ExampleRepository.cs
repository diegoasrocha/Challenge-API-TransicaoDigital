using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraData.Context;
using InfraData.Repositories.Base;

namespace Repos
{
    public class ExampleRepository : MySqlBaseRepository<Example>, IExampleRepository
    {
        public ExampleRepository(MySqlDbContext context) : base(context)
        {
        }
    }
}
