using KUSYS_Demo.Domain.Data.EntityFrameWork.UnitOfWorks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace KUSYS_Demo.Application.Business.Users.Commands;

public class LoginUserCommand : IRequest<bool>
{
    public string Email { get; set; }
    public string Password { get; set; }
}


public class LoginUserHandler : IRequestHandler<LoginUserCommand, bool>
{
    private readonly IUnitOfWork _uow;
    
    public LoginUserHandler(IUnitOfWork uow)
    {
        _uow = uow;
    }
    
    public async Task<bool> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _uow.User.ListNt(a => a.Email.Equals(request.Email) && a.Password.Equals(request.Password))
            .FirstOrDefaultAsync(cancellationToken);
        
        if (response is not null)
            return true;

        return false;
    }
}