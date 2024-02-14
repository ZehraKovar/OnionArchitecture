using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Mediator.User.AddUser
{
    public class AddUserHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IRepository<Domain.Entities.User> _repository;
        public AddUserHandler(IRepository<Domain.Entities.User> repository)
        {
            _repository = repository;
        }
        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Domain.Entities.User
            {
                UserName=request.UserName,
                Password=request.Password,
                Id=Guid.NewGuid(),
                RoleId=request.RoleId
            });
        }
    }
}
