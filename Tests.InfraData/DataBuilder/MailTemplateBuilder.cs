using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Tests.InfraData.DataBuilder
{
    public class MailTemplateBuilder
    {
        private MailTemplate MailTemplate;

        public MailTemplate CreateMailTemplate()
        {
            MailTemplate = new MailTemplate()
            {
                Id = Guid.NewGuid(),
                From = "test@tests.com",
                Body = null,
                Subject = null,
                Template = "Olá @Model.Name!",
                MailTemplateItems = new List<MailTemplateItem>()
                {
                    new MailTemplateItem() {
                        Id = Guid.NewGuid(),
                        Key = "@Model.Name",
                        Value = "Diego"
                    }
                }
            };

            var listItems = new List<MailTemplateItem>() 
            {
                new MailTemplateItem() {
                    Id = Guid.NewGuid(),
                    Key = "@Model.Name",
                    Value = "Diego",
                    MailTemplateId = MailTemplate.Id
                }
            };

            MailTemplate.MailTemplateItems = listItems;

            return MailTemplate;
        }
    }
}
