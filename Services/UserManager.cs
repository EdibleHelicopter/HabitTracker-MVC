using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

class UserManager
{
    string userPath = "userPath.json";
    List<User> userList = new List<User>();
    public int currentId;


    public void AddUser(User user)
    {
        userList.Add(user);
    }

    public List<User> DeserializeUsersFromFile()
    {
        if (File.Exists(userPath))
        {
            string jsonContent = File.ReadAllText(userPath);
            userList = JsonSerializer.Deserialize<List<User>>(jsonContent);
        }
        return userList;
    }

    public void Serialize(User user)
    {
        user.Id++;
        string json;
        if (File.Exists(userPath))
        {
            json = File.ReadAllText(userPath);
            userList =  JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        AddUser(user);
        json = JsonSerializer.Serialize(userList, new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        });
        File.WriteAllText(userPath, json);
    }

    public void Login(User thisUser)
    {
        if (File.Exists(userPath))
        {
           string json = File.ReadAllText(userPath);
           userList =  JsonSerializer.Deserialize<List<User>>(json); 
           foreach(User user in userList)
            {
                if(thisUser.login == user.login & thisUser.password == user.password)
                {
                    currentId = user.Id;
                    Console.WriteLine($"user id - {currentId}");
                }
            }
        }
    }
}