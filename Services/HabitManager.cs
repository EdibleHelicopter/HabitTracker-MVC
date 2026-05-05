using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;


public class HabitManager()
{
    public List<Habit> habitList = new List<Habit>(20);
    string habitsPath = "habitsPath.json";

    public List<Habit> GetHabit()
    {
        return habitList;
    }

    public List<Habit> DeserializeHabitsFromFile()
    {
        string jsonString = File.ReadAllText(habitsPath);
        return JsonSerializer.Deserialize<List<Habit>>(jsonString);
    }
    public void AddHabit(Habit habit)
    {
        habitList.Add(habit);
    }

    public void DeleteHabit(byte number)
    {
        habitList.RemoveAt(number - 1);
    }

    public void Serialize(Habit habit)
    {
        habitList.Add(habit);
        
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        };
        string json = JsonSerializer.Serialize(habitList, options);
        File.AppendAllText(habitsPath, json); //+ Environment.NewLine);
       
    }


    public void Deserialize()
    {
        string json = File.ReadAllText(habitsPath);
        Habit restoredHabit = JsonSerializer.Deserialize<Habit>(json);
    }

    public string GetText()
    {
        string text = File.ReadAllText(habitsPath);
        return text;
    }
}