using System.Text.Json;

class JsonHabitSerializer
{
    string json;
    public void Serialize(Habit habit)
    {
        json  = JsonSerializer.Serialize(habit);
        Console.WriteLine(json);
    }

    public void Print()
    {
        Console.WriteLine(json);
    }
}