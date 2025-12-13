using Blogy.Business.DTOS.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Validators.CategoryValidators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz !!")
                               .MinimumLength(3).WithMessage("Kategori Adı en az 3 karakter olmalıdır !!")
                               .MaximumLength(50).WithMessage("Kategori adı en fazla 50 karakter olmalıdır!!");
        }
    }
}
