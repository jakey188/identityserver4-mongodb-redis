using MediatR;

namespace IdentityServer.Management.Application.Users.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResult>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string PlainTextPassword { get; set; }
    }
}