using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table(name: "mail_template_item")]
    public class MailTemplateItem
    {
        [Key]
        [Column(name: "id")]
        [StringLength(36)]
        public Guid Id { get; set; }

        [Column(name: "key")]
        [StringLength(50)]
        public string Key { get; set; }

        [Column(name: "value")]
        [StringLength(100)]
        public string Value { get; set; }

        [Column(name: "mail_template_id")]
        [ForeignKey(nameof(MailTemplate))]
        [StringLength(36)]
        public Guid MailTemplateId { get; set; } 


        public virtual MailTemplate MailTemplate { get; set; }
    }
}
