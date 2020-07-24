using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("mail_template")]
    public class MailTemplate
    {
        [Key]
        [Column(name: "id")]
        [StringLength(36)]
        public Guid Id { get; set; }

        [Column(name: "from")]
        [StringLength(50)]
        public string From { get; set; }

        [Column(name: "subject")]
        [StringLength(100)]
        public string Subject { get; set; }

        [Column(name: "body")] 
        public string Body { get; set; }

        [Column(name: "template")] 
        public string Template { get; set; }


        public virtual IEnumerable<MailTemplateItem> MailTemplateItems { get; set; }
    }
}
