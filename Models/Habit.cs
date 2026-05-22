using System.Linq.Expressions;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.SignalR;


public class Habit()
{
   public string Name{get; set;}
   public int Id{get; set;}
}

/*
public class Habit
{
    public string Name{get; set;}
    public string Description{get; set;}

    public Habit()
    {
      Name = "Undefined";
      Description = "Пусто";
    }    
    
}
*/



/*
public class Habit
{
    public  int Id {get; private set;}
    static int TempId  = 0;

    public string Name {get; set;}
    public string Description {get; private set;}
 
    public enum HabitType
    {
        neutral,
        positive,
        negative
    }

    public HabitType Type = new HabitType();


 
    public Habit(string name, string description, HabitType type)
    {
        
        Id = TempId;
        Name = name;
        Description = description;
        Type = type;
        TempId++;
    }

    public Habit()
    {
        Id = TempId;
        Name = "Undefined";
        Description = "Пусто";
        Type = HabitType.neutral;
        TempId++;
    }    
    
}
*/


