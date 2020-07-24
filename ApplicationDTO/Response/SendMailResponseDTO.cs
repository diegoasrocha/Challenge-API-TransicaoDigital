
namespace ApplicationDTO.Response
{
    public class SendMailResponseDTO
    {
        public bool Success { get; set; }
     
        public SendMailResponseDTO(bool success)
        {
            Success = success;
        }
    }
}
