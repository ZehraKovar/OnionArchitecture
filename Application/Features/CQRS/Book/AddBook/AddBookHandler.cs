using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Book.AddBook
{
    public class AddBookHandler
    {
        private readonly IRepository<Domain.Entities.Book> _repository;
        public AddBookHandler(IRepository<Domain.Entities.Book> repository)
        {
            _repository = repository;
        }

        public async Task Handler(AddBookCommand command)
        {
            await _repository.CreateAsync(new Domain.Entities.Book
            {
                Name=command.Name,
                Id=Guid.NewGuid()
            });
        }
    }
}
