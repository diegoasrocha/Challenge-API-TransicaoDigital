using ApplicationService.Interfaces;
using Domain.Interfaces.Repositories;
using System;

namespace ApplicationService.Services
{
    public class ExampleService : IExampleService
    {

        private readonly IExampleRepository _exampleRepository;

        public ExampleService(IExampleRepository exampleRepository)
        {
            _exampleRepository = exampleRepository ?? throw new ArgumentNullException(nameof(exampleRepository)); ;
        }

        public void DoExampleOp()
        {
            //_exampleRepository.DoExampleOp();
        }
    }
}
