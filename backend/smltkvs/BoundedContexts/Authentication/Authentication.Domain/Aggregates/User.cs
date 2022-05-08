using Authentication.Domain.Enums;

namespace Authentication.Domain.Aggregates;

public class User
{
    public Guid UserId { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public Role Role { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    
    public User(Guid userId, string username, string password, Role role)
    {
        UserId = userId;
        Username = username;
        Password = password;
        Role = role;
        //TODO: password hasher
    }
    
    public User(Guid userId, string username, string password, Role role, string email, string name) 
    {
        UserId = userId;
        Username = username;
        Password = password;
        Role = role;
        Email = email;
        Name = name;
    }
}