using Core.DTOs;
using Core.Exceptions;
using Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _config;

        private string _passwordHash => _config["AdminPasswordHash"];
        private string _jwtSecret => _config["Jwt:Secret"];
        private int _jwtLifetime => _config.GetValue<int>("Jwt:Lifetime");

        public AuthenticationService(IConfiguration config)
        {
            _config = config;
        }

        public TokenDTO Authenticate(CredentialsDTO credentials)
        {
            var isPasswordValid = BCrypt.Net.BCrypt.Verify(credentials.Password, _passwordHash);

            if (!isPasswordValid)
            {
                throw new InvalidCredentialsException("Password is incorrect.");
            }

            var jwt = CreateNewJwt();

            var token = new TokenDTO { Token = new JwtSecurityTokenHandler().WriteToken(jwt) };

            return token;
        }

        private JwtSecurityToken CreateNewJwt()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSecret));

            var jwt = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(_jwtLifetime),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256));

            return jwt;
        }
    }
}
