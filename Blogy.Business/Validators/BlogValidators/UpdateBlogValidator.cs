using Blogy.Business.DTOs.BlogDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Validators.BlogValidators
{
    public class UpdateBlogValidator :AbstractValidator<UpdateBlogDto>
    {
        public UpdateBlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık kısmı boş bırakılamaz !!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama kısmı boş bırakılamaz!!");
            RuleFor(x => x.BlogImage1).NotEmpty().WithMessage("Blog Resmi 1 kısmı boş bırakılamaz!!");
            RuleFor(x => x.CoverImage).NotEmpty().WithMessage("Kapak resmi kısmı boş bırakılamaz!!");
            RuleFor(x => x.BlogImage2).NotEmpty().WithMessage("Blog Resmi 2 kısmı boş bırakılamaz!!");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori kısmı boş bırakılamaz!!");
        }
    }
}
