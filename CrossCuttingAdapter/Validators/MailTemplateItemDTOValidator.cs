using ApplicationDTO.Request;
using FluentValidation;

namespace CrossCuttingAdapter.Validators
{
    public class MailTemplateItemDTOValidator : AbstractValidator<MailTemplateItemDTO>
    {
        public MailTemplateItemDTOValidator()
        {
            RuleFor(p => p.Key).NotEmpty().WithMessage("Informar o campo \"Key\"");
            RuleFor(p => p.Value).NotEmpty().WithMessage("Informar o campo \"Value\"");
        }
    }
}
