using ApplicationDTO.Request;
using FluentEmail.Core.Models;
using System.Threading.Tasks;

namespace ApplicationService.Interfaces
{
    public interface IMailService
    { 
        Task<SendResponse> SendMail(SendMailDTO sendMailDTO);
    }
}
