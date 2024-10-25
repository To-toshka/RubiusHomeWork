// See https://aka.ms/new-console-template for more information
using Lesson1.Models;

var student = new Student
{
    FirstName = "Eugene",
    LastName = "Verbovskyi",
    Age = 34,
    Gender = "Male",
    Language = "Russian"
}; 

Console.WriteLine($"Hello, I`m {student.FirstName} {student.LastName}");
Console.WriteLine($"Мне {student.Age} года");
student.HappyBirthday();
Console.WriteLine($"Теперь мне {student.Age} лет");