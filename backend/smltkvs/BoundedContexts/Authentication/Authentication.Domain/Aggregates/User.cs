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
    
   //  public User(string username, string password, Role role)
   //  {
   //      UserId = Guid.NewGuid();
   //      Username = username;
   //      Password = password;
   //      Role = role;
   //  }
    
    public User(string username, string password, Role role, string email, string name) 
    {
        UserId = Guid.NewGuid();
        Username = username;
        Password = password;
        Role = role;
        Email = email;
        Name = name;
        //TODO: password hasher
    }
}