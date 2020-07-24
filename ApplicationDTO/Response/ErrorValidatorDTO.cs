using System.Collections.Generic; 

namespace ApplicationDTO.Response
{
    public class ErrorValidatorDTO
    {
        public IList<string> Erros { get; set; }

        public ErrorValidatorDTO(IList<string> erros)
        {
            Erros = erros;
        }
    }
}
