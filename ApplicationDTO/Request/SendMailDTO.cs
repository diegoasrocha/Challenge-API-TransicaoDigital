using System;
using System.Collections.Generic; 

namespace ApplicationDTO.Request
{
    public class SendMailDTO
    {
        public Guid MailTemplateId { get; set; }

        public string MailRecipient { get; set; }

        public ICollection<MailTemplateItemDTO> MailTemplateItems { get; set; }
    }
}
