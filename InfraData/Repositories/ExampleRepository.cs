using Domain.Entities;
using Domain.Interfaces.Repositories;
using InfraData.Context;
using InfraData.Repositories.Base;

namespace InfraData.Repositories
{
    public class ExampleRepository : MySqlBaseRepository<Example>, IExampleRepository
    {
        public ExampleRepository(MySqlDbContext context) : base(context)
        {
        }

        public void DoExampleOp()
        {
            throw new System.NotImplementedException();
        }
    }
}
