using System.Text.Json;

public class HabitManager()
{
    public List<Habit> habitList = new List<Habit>(20);
    string habitsPath = "habitsPath.json";

    public List<Habit> GetHabit()
    {
        return habitList;
    }
    public void AddHabit(Habit habit)
    {
        habitList.Add(habit);
    }

    public void DeleteHabit(byte number)
    {
      habitList.RemoveAt(number-1);
    } 
        
    public void Serialize(Habit habit)
    {
        string json  = JsonSerializer.Serialize(habit);
        File.AppendAllText(habitsPath, json + Environment.NewLine);
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