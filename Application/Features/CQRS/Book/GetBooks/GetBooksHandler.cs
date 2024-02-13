using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Book.GetBooks
{
    public class GetBooksHandler
    {
        private readonly IRepository<Domain.Entities.Book> _repository;
        public GetBooksHandler(IRepository<Domain.Entities.Book> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBookResults>> Handler()
        {
            var values = await _repository.GetAllAsycc();
            return values.Select(x => new GetBookResults
            {
                Id=x.Id,
                Name=x.Name
            }).ToList();
        }
    }
}
