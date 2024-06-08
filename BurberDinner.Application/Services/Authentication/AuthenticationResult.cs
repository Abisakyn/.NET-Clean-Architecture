using BurberDinner.Domain.Entities;

namespace BurberDinner.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}