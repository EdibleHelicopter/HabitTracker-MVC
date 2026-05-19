using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;

class UserManager
{
    string userPath = "userPath.json";
    List<User> userList = new List<User>();

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
}