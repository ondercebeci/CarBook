using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;

namespace UdemyCarBook.Application.Validator.ReviewValidator
{
    public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteriadını boş geçmeyiniz!");
            RuleFor(x => x.CustomerName).MinimumLength(4).WithMessage("Lütfen en az 4 karakter veri girişi yapınız");
            RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puan değerini boş bırakmayınız.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen Yorum Alanını boş geçmeyiniz!");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmına en az 50 karakter veri girişi yapınız");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen yorum kısmına en fazla 500 karakter veri girişi yapınız.");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen Müşteri Görseli Alanını boş geçmeyiniz!");

        }
    }
}
