using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Features.Mediator.Book.AddBook
{
    public class AddBookCommand:IRequest
    {
        public string Name {  get; set; }
    }
}
