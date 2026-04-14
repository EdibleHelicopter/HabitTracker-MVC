using System.Text.Json;

class HabitManager()
{
    static private List<Habit> habitList = new List<Habit>(20);
    private string json;
    
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
        json  = JsonSerializer.Serialize(habit);
        Console.WriteLine(json);
    }
     
    public void Deserialize()
    {
        Habit? restoredHabit = JsonSerializer.Deserialize<Habit>(json);
    }

    public void Print()
    {
        Console.WriteLine(json);
    }
        
}