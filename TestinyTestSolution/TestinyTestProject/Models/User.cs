using TestinyTestProject.Models.Enums;

namespace TestinyTestProject.Models;

public record User
{
    public UserType UserType { get; set; } = UserType.Admin;
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}
