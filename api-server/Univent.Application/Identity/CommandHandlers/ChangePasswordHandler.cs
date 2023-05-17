using MediatR;
using Microsoft.AspNetCore.Identity;
using Univent.Application.Exceptions;
using Univent.Application.Identity.Commands;

namespace Univent.Application.Identity.CommandHandlers
{
    internal class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ChangePasswordHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Unit> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var identityUser = await _userManager.FindByIdAsync(request.UserID);
            if (identityUser == null)
            {
                throw new IdentityUserNotFoundByIdException(request.UserID);
            }

            //Check if Password is correct
            var validPassword = await _userManager.CheckPasswordAsync(identityUser, request.OldPassword);
            if (!validPassword)
            {
                throw new IdentityUserIncorrectPasswordByIdException(request.UserID);
            }

            var updatedIdentity = await _userManager.ChangePasswordAsync(identityUser, request.OldPassword, request.NewPassword);
            if(!updatedIdentity.Succeeded)
            {
                throw new IdentityPasswordUpdateFailedException();
            }

            return new Unit();
        }
    }
}
