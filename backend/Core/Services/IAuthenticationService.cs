using Core.DTOs;

namespace Core.Services
{
    public interface IAuthenticationService
    {
        TokenDTO Authenticate(CredentialsDTO credentials);
    }
}
