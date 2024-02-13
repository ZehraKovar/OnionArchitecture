using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Book.AddBook
{
    public class AddBookCommand
    {
        public string Name {  get; set; }
    }
}
