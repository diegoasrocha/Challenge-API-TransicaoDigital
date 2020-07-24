using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Transactions
{
    public interface IUnitOfWork : IRepositoryRoot, IDisposable
    {
        Task OpenConnectionAsync(DataSource source);

        Task CloseConnectionAsync(DataSource source);

        Task BeginTransactionAsync(DataSource source);

        void Commit(DataSource source);

        void RollBack(DataSource source);
    }
}
