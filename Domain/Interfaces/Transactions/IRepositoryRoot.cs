using Domain.Interfaces.Repositories;

namespace Domain.Interfaces.Transactions
{

    /// <summary>
    /// Interface that represents the root of the repositories aggregate. It facilitates 
    /// the injection of all repositories without giving access to transaction methods 
    /// for those who should not have access. If the layer should not control transaction, 
    /// do not inject as a unit, inject as IRepositoryRoot
    /// </summary>
    public interface IRepositoryRoot
    {
        /// <summary>
        /// Data access for Users
        /// </summary>
        IExampleRepository ExampleRepository { get; }
        IMailTemplateRepository MailTemplateRepository { get; }
        IMailTemplateItemRepository MailTemplateItemRepository { get; }
    }
}
