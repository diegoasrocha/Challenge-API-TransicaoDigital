using Newtonsoft.Json;
using System; 

namespace ApplicationDTO.Response
{
    public class MailTemplateItemDTO
    { 
        public Guid Id { get; set; }
         
        public string Key { get; set; }
         
        public string Value { get; set; } 

        public Guid MailTemplateId { get; set; }
    }
}
