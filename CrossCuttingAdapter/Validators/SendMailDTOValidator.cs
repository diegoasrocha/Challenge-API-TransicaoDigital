using ApplicationDTO.Request;
using FluentValidation;

namespace CrossCuttingAdapter.Validators
{
    public class SendMailDTOValidator : AbstractValidator<SendMailDTO>
    {
        public SendMailDTOValidator()
        {
            RuleFor(p => p.MailTemplateId).NotEmpty().WithMessage("Informar o campo \"MailTemplateId\"");
            RuleFor(p => p.MailRecipient).NotEmpty().WithMessage("Informar o campo \"MailRecipient\"");
            RuleFor(p => p.MailTemplateItems).NotEmpty().WithMessage("Informar o campo \"MailTemplateItems\"");
        }
    }
}
