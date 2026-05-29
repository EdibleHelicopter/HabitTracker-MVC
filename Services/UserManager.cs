using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

class UserManager
{
    string userPath = "userPath.json";
    string folderPath = @"C:\Users";
    string idSave = "SaveId.json";
    List<User> userList = new List<User>();
    public int currentId;

    public UserManager()
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            Console.WriteLine($"создана папка {folderPath}");
        }
        else
        {
            string folderInfo = Path.GetFullPath(folderPath);
            Console.WriteLine(folderPath);
        }
    }
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

        json = File.ReadAllText(idSave);
        user.Id = JsonSerializer.Deserialize<int>(json);
        Console.WriteLine(user.Id);
        user.Id++;
        json = JsonSerializer.Serialize(user.Id);
        File.WriteAllText(idSave, json);

        if (File.Exists(userPath))
        {
            json = File.ReadAllText(userPath);
            userList = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
        }
        currentId = user.Id;
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
            userList = JsonSerializer.Deserialize<List<User>>(json);
            foreach (User user in userList)
            {
                if (thisUser.login == user.login & thisUser.password == user.password)
                {
                    currentId = user.Id;
                    Console.WriteLine($"user id - {currentId}");
                }
            }
        }
    }
}