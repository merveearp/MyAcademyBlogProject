using Blogy.Business.DTOs.ContactMessageDtos;
using Blogy.Entity.Entities;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Validators.ContactMessageValidators
{
    public class CreateContactMessageValidator : AbstractValidator<ContactMessage>
    {

        public CreateContactMessageValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim-Soyisim Alanı Boş Bırakılamaz !!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Bırakılamaz !!");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Bırakılamaz !!");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Alanı Boş Bırakılamaz !!")
                                    .MinimumLength(10).WithMessage("Mesajınız MİNİMUM 10 karakter olmalıdır.");
                               
        }
    }
}
