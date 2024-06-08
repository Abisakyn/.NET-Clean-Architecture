using BurberDinner.Domain.Entities;

namespace BurberDinner.Application.Common.Interfaces.Authentication;

public interface IjwtTokenGenerator
{
    string GenerateToken(User user);
}