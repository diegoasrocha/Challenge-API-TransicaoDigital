using System;
using System.Collections.Generic; 
using System.Linq; 
using ApplicationDTO.Request;
using ApplicationDTO.Response;
using ApplicationService.Interfaces;
using AutoMapper.Internal;
using CrossCuttingAdapter.Validators;
using Domain.Exceptions; 
using FluentValidation.Results; 
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost]
        [Route("Send")]
        [ProducesResponseType(200, Type = typeof(SendMailResponseDTO))]
        [ProducesResponseType(400, Type = typeof(ErrorValidatorDTO))]
        [ProducesResponseType(422, Type = typeof(string))]
        public ActionResult<bool> Send(SendMailDTO sendMail)
        {
            try
            {
                ValidationResult result = new SendMailDTOValidator().Validate(sendMail);

                if (!result.IsValid)
                {
                    IList<string> erros = new List<string>();

                    result.Errors.ForAll(s => erros.Add(s.ErrorMessage));

                    throw new ValidationDTOException(erros);
                }

                var res = _mailService.SendMail(sendMail).Result;

                return Ok(new SendMailResponseDTO(res.Successful));
            }
            catch (ValidationDTOException ex) 
            {
                return BadRequest(new ErrorValidatorDTO(ex.Errors));
            }
            catch (Exception ex)
            {
                if ((ex.InnerException ?? ex) is NotFoundException)
                    return NotFound(ex.Message);

                return UnprocessableEntity(ex.Message);
            }

        }
    }
}
