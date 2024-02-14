using Application.Features.Mediator.Book.AddBook;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class BookValidator:AbstractValidator<AddBookCommand>
    {
        public BookValidator()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().WithMessage("Kitap adı boş veya null olamaz!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kitap adı en az 3 karakter olmalıdır!");
        }
    }
}
