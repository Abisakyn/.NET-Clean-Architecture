using BurberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IjwtTokenGenerator _jwtTokenGenerator; 

        public AuthenticationService(IjwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //check if the user already exists

            //create user(genarate unique identifier)

            //create JWT token
            Guid userId= Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId,firstName,lastName);
            return new AuthenticationResult(
                userId,
                firstName,
                lastName,
                email,
                password,
                token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "firstName",
                "lastName",
                email,
                password,
                "token");
        }
    }
}
