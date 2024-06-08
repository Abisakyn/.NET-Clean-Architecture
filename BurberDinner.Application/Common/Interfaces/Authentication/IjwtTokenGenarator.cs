namespace BurberDinner.Application.Common.Interfaces.Authentication;

public interface IjwtTokenGenerator
{
    string GenerateToken(Guid userId, string firstName, string lastName);
}