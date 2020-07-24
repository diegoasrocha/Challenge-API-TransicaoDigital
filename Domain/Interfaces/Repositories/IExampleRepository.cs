using Domain.Entities;
using Domain.Interfaces.Repositories.Base;

namespace Domain.Interfaces.Repositories
{
    public interface IExampleRepository : IAsyncRepository<Example>
    {
        void DoExampleOp();
    }
}
