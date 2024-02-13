using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Book.GetBooks
{
    public class GetBookResults
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
