class HabitManager()
{
    public List<Habit> habitList = new List<Habit>(20);
    
    
    public void AddHabit(string Name, string Description, Habit.Type type)
    {
        habitList.Add(new Habit(Name, Description, type));
    }
    

    public void DeleteHabit(byte number)
    {
      habitList.RemoveAt(number-1);
    } 
        
}