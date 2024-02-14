using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Book.GetBooks
{
    public class GetBooksQuery:IRequest<List<GetBookResult>>
    {
    }
}
