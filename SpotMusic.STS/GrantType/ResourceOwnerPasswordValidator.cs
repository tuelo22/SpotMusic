using IdentityModel;
using IdentityServer4.Validation;
using SpotMusic.STS.Data;

namespace SpotMusic.STS.GrantType
{
    public class ResourceOwnerPasswordValidator(IIdentityRepository repository) : IResourceOwnerPasswordValidator
    {
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var senha = context.Password;
            var email = context.UserName;

            var user = await repository.FindByEmailAndPasswordAsync(email, Domain.Extensions.StringExtensions.Criptografar(senha));

            if (user is not null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }
        }
    }
}
