using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Authentication.CheckUser
{
    public class CheckUserResult
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsExist {  get; set; }
        public string Id {  get; set; }
    }
}
