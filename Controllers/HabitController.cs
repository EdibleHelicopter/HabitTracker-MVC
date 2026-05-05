using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class HabitController : Controller
{
    HabitManager manager = new HabitManager();
    

   /* public IActionResult Index()
    {

         string jsonFilePath = "habitsPath.json"; 
         manager.habitList = manager.DeserializeHabitsFromFile();
         return View(manager.habitList);
    }
    */
    public IActionResult Index()
{
    string jsonFilePath = "habitsPath.json"; 

    try
    {
        jsonFilePath = "habitsPath.json"; 
         manager.habitList = manager.DeserializeHabitsFromFile();
        return View(manager.habitList);
    }
    catch (FileNotFoundException ex)
    {
        // Обработка случая, когда JSON-файл не найден
        Console.WriteLine($"Ошибка: Файл не найден. Путь: {jsonFilePath}");
        Console.WriteLine($"Детали ошибки: {ex.Message}");

        // Инициализируем пустой список привычек и передаём в представление
        manager.habitList = new List<Habit>();
        return View(manager.habitList);
    }
    catch (JsonException ex)
    {
        // Обработка ошибок десериализации (некорректный JSON или несоответствие структуры)
        Console.WriteLine($"Ошибка десериализации JSON: {ex.Message}");
        Console.WriteLine($"Путь к файлу: {jsonFilePath}");

        
        // Возвращаем пустой список или сообщение об ошибке
        manager.habitList = new List<Habit>();
        ViewBag.ErrorMessage = "Не удалось загрузить данные из JSON-файла. Структура файла некорректна.";
        return View(manager.habitList);
    }
    catch (IOException ex)
    {
        // Обработка ошибок ввода-вывода (например, файл заблокирован или недоступен)
        Console.WriteLine($"Ошибка ввода-вывода при чтении файла: {ex.Message}");

        manager.habitList = new List<Habit>();
        ViewBag.ErrorMessage = "Не удалось прочитать JSON-файл. Проверьте права доступа и состояние файла.";
        return View(manager.habitList);
    }
    catch (Exception ex)
    {
        // Обработка всех остальных непредвиденных исключений
        Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
        Console.WriteLine($"StackTrace: {ex.StackTrace}");

        manager.habitList = new List<Habit>();
        ViewBag.ErrorMessage = "Произошла ошибка при загрузке данных. Пожалуйста, попробуйте позже.";
        return View(manager.habitList);
    }
}

    
        [HttpPost]
        public IActionResult AddHabit(Habit habit)
        {
            manager.Serialize(habit);
            foreach(Habit _habit in manager.habitList)
            {
                Console.WriteLine(_habit.Name);
            }
            return RedirectToAction("Index");
        }
        
}



