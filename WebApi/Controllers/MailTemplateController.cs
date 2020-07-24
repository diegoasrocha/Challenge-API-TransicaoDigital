using System.Collections.Generic; 
using ApplicationDTO.Response;
using ApplicationService.Interfaces; 
using Microsoft.AspNetCore.Mvc; 

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MailTemplateController : ControllerBase
    {
        private readonly IMailTemplateService _mailTemplateService;

        public MailTemplateController(IMailTemplateService mailTemplateService)
        {
            _mailTemplateService = mailTemplateService;
        }

        [HttpGet]
        [Route("AllMailTemplates")]
        [ProducesResponseType(200, Type = typeof(ICollection<MailTemplateDTO>))]
        public ActionResult<ICollection<MailTemplateDTO>> Get()
        {
            var response = _mailTemplateService.AllMainTemplates().Result;

            return Ok(response);
        }

        [HttpGet]
        [Route("AllMailTemplatesWithItems")]
        [ProducesResponseType(200, Type = typeof(ICollection<MailTemplateDTO>))]
        public ActionResult<ICollection<MailTemplateDTO>> GetWithItems()
        {
            var response = _mailTemplateService.AllMainTemplatesWithItems().Result;

            return Ok(response);
        }


    }
}
