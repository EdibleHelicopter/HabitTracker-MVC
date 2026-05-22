public class User
{
    public string login {get; set;}
    public string password {get; set;}
    public int Id {get; set;}

    static int IdCount;

    public User()
    {
        IdCount++;
        Id = IdCount;
    }
    
}