using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Book.AddBook
{
    public class AddBookHandler : IRequestHandler<AddBookCommand>
    {
        private readonly IRepository<Domain.Entities.Book> _repository;
        public AddBookHandler(IRepository<Domain.Entities.Book> repository)
        {
            _repository = repository;
        }
        public async Task Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            await  _repository.CreateAsync(new Domain.Entities.Book
            {
                Id=Guid.NewGuid(),
                Name=request.Name,
            });
        }
    }
}
