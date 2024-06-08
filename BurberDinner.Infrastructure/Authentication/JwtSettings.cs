namespace BurberDinner.Infrastructure.Authentication;

public class JwtSettings
{
    public const string sectionName ="JwtSettings";
 public string? Secret { get; init; }
 public string? Issuer{ get; init; }

 public string? Audience{ get; init; }

 public int ExpiryInMinutes { get; init; }
}
