using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;


public class HabitManager()
{
    public List<Habit> habitList = new List<Habit>(20);
    string habitsPath = "habitsPath.json";

    public List<Habit> DeserializeHabitsFromFile()
    {
        
        if(File.Exists(habitsPath))
        {
            string jsonContent = File.ReadAllText(habitsPath);
            habitList = JsonSerializer.Deserialize<List<Habit>>(jsonContent); //?? new List<Habit>();
        }
        return habitList;
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
        
        if(File.Exists(habitsPath))
        {
            string jsonContent = File.ReadAllText(habitsPath);
            habitList = JsonSerializer.Deserialize<List<Habit>>(jsonContent) ?? new List<Habit>();
        }
        
        habitList.Add(habit);
        string updatedJson =  JsonSerializer.Serialize(habitList, new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        });

        File.WriteAllText(habitsPath, updatedJson);
    }
}