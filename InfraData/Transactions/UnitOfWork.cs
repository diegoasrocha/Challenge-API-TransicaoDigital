using Domain.Interfaces.Repositories;
using Domain.Interfaces.Transactions;
using InfraData.Context;
using InfraData.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace InfraData.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposedValue = false;
        private MySqlDbContext _mySqlcontext;
        private IExampleRepository _exampleRepository;
        private IMailTemplateRepository _mailTemplateRepository;
        private IMailTemplateItemRepository _mailTemplateItemRepository;

        public IExampleRepository ExampleRepository =>
                _exampleRepository ?? (_exampleRepository = new ExampleRepository(context: _mySqlcontext));

        public IMailTemplateRepository MailTemplateRepository =>
                _mailTemplateRepository ?? (_mailTemplateRepository = new MailTemplateRepository(context: _mySqlcontext));

        public IMailTemplateItemRepository MailTemplateItemRepository =>
                _mailTemplateItemRepository ?? (_mailTemplateItemRepository = new MailTemplateItemRepository(context: _mySqlcontext));

        public Task BeginTransactionAsync(DataSource source)
        {
            switch (source)
            {
                case DataSource.MySql:
                    return _mySqlcontext.Database.BeginTransactionAsync();

                default:
                    throw new NotSupportedException($"BeginTransactionAsync not implemented for {source}");
            }
        }

        public Task CloseConnectionAsync(DataSource source)
        {
            switch (source)
            {
                case DataSource.MySql:
                    return _mySqlcontext.Database.CloseConnectionAsync();

                default:
                    throw new NotSupportedException($"CloseConnectionAsync not implemented for {source}");
            }
        }

        public void Commit(DataSource source)
        {
            switch (source)
            {
                case DataSource.MySql:
                    _mySqlcontext.Database.CurrentTransaction?.Commit();
                    break;
                default:
                    throw new NotSupportedException($"Commit not implemented for {source}");
            }
        }

        public Task OpenConnectionAsync(DataSource source)
        {
            switch (source)
            {
                case DataSource.MySql:
                    return _mySqlcontext.Database.OpenConnectionAsync();

                default:
                    throw new NotSupportedException($"OpenConnectionAsync not implemented for {source}");
            }
        }

        public void RollBack(DataSource source)
        {
            switch (source)
            {
                case DataSource.MySql:
                    _mySqlcontext.Database.CurrentTransaction?.Rollback();
                    break;
                default:
                    throw new NotSupportedException($"RollBack not implemented for {source}");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _mySqlcontext?.Dispose();
                    _mySqlcontext = null;
                }

                _disposedValue = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
