namespace Authentication.Domain.Aggregates;

public class User
{
    public Guid UserId { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }

    public User(Guid userId, string username, string password)
    {
        UserId = userId;
        Username = username;
        Password = password;
        
        //TODO: password hasher
    }
}