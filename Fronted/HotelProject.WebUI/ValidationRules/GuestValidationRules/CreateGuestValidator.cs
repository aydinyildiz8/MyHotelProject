using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        public CreateGuestValidator()
        {
            RuleFor(x => x.GuestName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.");
            RuleFor(x => x.GuestName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");
            RuleFor(x => x.GuestName).MaximumLength(25).WithMessage("Lütfen en fazla 25 karakter veri girişi yapınız.");

            RuleFor(x => x.GuestSurName).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.");
            RuleFor(x => x.GuestSurName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");
            RuleFor(x => x.GuestSurName).MaximumLength(25).WithMessage("Lütfen en fazla 25 karakter veri girişi yapınız.");

            RuleFor(x => x.GuestCity).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.");
            RuleFor(x => x.GuestCity).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");
            RuleFor(x => x.GuestCity).MaximumLength(25).WithMessage("Lütfen en fazla 25 karakter veri girişi yapınız.");

            RuleFor(x => x.GuestTcNumber).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.");
            RuleFor(x => x.GuestGender).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.");
            RuleFor(x => x.GuestPhone).NotEmpty().WithMessage("Bu Alan Boş Geçilemez.");
        }
    }
}
