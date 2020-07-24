using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ApplicationDTO.Response
{ 
    public class MailTemplateDTO
    { 
        public Guid Id { get; set; }
         
        public string From { get; set; }
         
        public string Subject { get; set; }
         
        public string Body { get; set; }
         
        public string Template { get; set; }

         
        public ICollection<MailTemplateItemDTO> MailTemplateItems { get; set; }
    }
}
