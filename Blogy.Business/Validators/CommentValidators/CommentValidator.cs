using Blogy.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Validators.CommentValidators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Kullanıcı Boş Olamaz");
            RuleFor(x => x.BlogId).NotEmpty().WithMessage("Blog Boş Olamaz");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Yorum alanı Boş Olamaz")
                .MaximumLength(250).WithMessage("Yorum İçeriği 250 karakterden uzun olamaz");

        }
    }
}
