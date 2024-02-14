using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Authentication.CheckUser
{
    public class CheckUserQuery:IRequest<CheckUserResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
