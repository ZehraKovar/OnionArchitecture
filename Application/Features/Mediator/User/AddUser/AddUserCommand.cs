using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.User.AddUser
{
    public class AddUserCommand:IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid RoleId {  get; set; }
    }
}
