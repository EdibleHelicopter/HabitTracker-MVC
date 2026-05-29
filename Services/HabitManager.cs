using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;


public class HabitManager()
{
    public List<Habit> habitList = new List<Habit>();
    string folderPath = @"C:\JsonFiles\Habits";

    string habitsPath;
    
    
    public void LoadHabits(int userId)
    {
        habitsPath = userId.ToString() + ".json";
        DeserializeHabitsFromFile();
    }

    public List<Habit> DeserializeHabitsFromFile()
    {

        if (File.Exists(habitsPath))
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

    public void Serialize(Habit habit, int userId)
    {
        habitsPath = userId.ToString() + ".json";

        if (File.Exists(habitsPath))
        {
            string jsonContent = File.ReadAllText(habitsPath);
            habitList = JsonSerializer.Deserialize<List<Habit>>(jsonContent) ?? new List<Habit>();
        }

        habitList.Add(habit);
        string updatedJson = JsonSerializer.Serialize(habitList, new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true
        });

        File.WriteAllText(habitsPath, updatedJson);
    }
}