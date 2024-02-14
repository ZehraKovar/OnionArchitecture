using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Book.GetBooks
{
    public class GetBooksHandler : IRequestHandler<GetBooksQuery, List<GetBookResult>>
    {
        private readonly IRepository<Domain.Entities.Book> _repository;
        public GetBooksHandler(IRepository<Domain.Entities.Book> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetBookResult>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetAllAsycc();
            return values.Select(x => new GetBookResult
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
