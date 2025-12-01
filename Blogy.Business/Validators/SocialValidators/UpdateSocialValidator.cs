using Blogy.Business.DTOs.SocialDtos;
using Blogy.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Validators.SocialValidators
{
    public class SocialValidator : AbstractValidator<UpdateSocialDto>
    {
        public SocialValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("Sosyal Ağ Adı Boş Bırakılamaz !!");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Sosyal Ağ ikon görseli olmak zorundadır!!");
                               
        }
    }
}
