using Domain.Interfaces.Repositories;
using InfraData.Context;
using InfraData.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using Tests.InfraData.DataBuilder;

namespace Tests.InfraData
{
    [TestFixture]
    public class MailTemplateRespositoryTest
    {
        private MySqlDbContext dbContext { get; set; }
        private IDbContextTransaction transaction;

        private IMailTemplateRepository mailTemplateRepository;
        private MailTemplateBuilder builder;

        [OneTimeSetUp]
        public void GlobalPrepare()
        {
            dbContext = new EntityFrameworkConnection().DataBaseConfiguration();
        }

        [SetUp]
        public void Inicializa()
        {
            mailTemplateRepository = new MailTemplateRepository(dbContext);
            builder = new MailTemplateBuilder();
            transaction = dbContext.Database.BeginTransaction();
        }

        [TearDown]
        public void ExecutadoAposExecucaoDeCadaTeste()
        {
            transaction.Rollback();
        }

        [Test]
        public async Task AddAsync()
        {
            var mailTemplatesBefore = mailTemplateRepository.GetAllAsync().Result.Count();

            await mailTemplateRepository.CreateAsync(builder.CreateMailTemplate());

            var mailTemplatesAfter = mailTemplateRepository.GetAllAsync().Result.Count();
            
            Assert.Greater(mailTemplatesAfter, mailTemplatesBefore);
        }
    }
}
