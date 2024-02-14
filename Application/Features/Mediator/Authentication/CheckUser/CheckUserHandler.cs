using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.Authentication.CheckUser
{
    public class CheckUserHandler : IRequestHandler<CheckUserQuery, CheckUserResult>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        public CheckUserHandler(IRepository<User> userRepository, IRepository<Role> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }
        public async Task<CheckUserResult> Handle(CheckUserQuery request, CancellationToken cancellationToken)
        {
            var res=new CheckUserResult();
            var user = _userRepository.GetByFilterAsync(x=>x.UserName==request.UserName && 
            x.Password==request.Password);
            if (user.Result == null)
            {
                res.IsExist = false;
            }
            else
            {
                res.IsExist = true;
                res.UserName = user.Result.UserName;
                res.Password = user.Result.Password;
                res.Role =_roleRepository.GetByIdAsync(user.Result.RoleId).Result.Name;
                res.Id = user.Id.ToString();
            }
            return res;
        }
    }
}
