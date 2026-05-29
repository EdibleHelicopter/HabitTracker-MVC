public class User
{
    public string login { get; set; }
    public string password { get; set; }
    static int idCount;
    public int Id { get; set; }

    public void ChangeId()
    {
        idCount++;
        Id = idCount;
    }

}