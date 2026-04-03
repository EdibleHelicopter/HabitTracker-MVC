using System.Linq.Expressions;

public class Habit
{
    public  int Id {get; private set;}
    static int TempId;
    public string Name {get; private set;}
    public string Description {get; private set;}
    public string Value;
    public enum Type
    {
        neutral,
        positive,
        negative
    }


    public Type type = new Type();



    public Habit(string Name, string Description, Type type)
    {
        Id = TempId;
        this.Name = Name;
        this.Description = Description;
        this.type = type;
        TempId++;
    }

    public Habit()
    {

        Id = TempId;
        Name = "Без имени";
        Description = "Пусто";
        type = Type.neutral;
        TempId++;
    }
    
}

