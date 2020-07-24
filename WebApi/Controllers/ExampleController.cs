using ApplicationService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        // Injected DataRoot service
        private readonly IExampleService _exampleService;

        // Constructor to inject DataRoot application service
        public ExampleController(IExampleService exampleService)
        {
            _exampleService = exampleService ?? throw new ArgumentNullException(nameof(exampleService));
        }
        
        [HttpGet]
        [Route("exampleOp")]
        public void DoExampleOp()
        {
            _exampleService.DoExampleOp();
        }

    }
}
