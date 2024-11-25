namespace Lesson5.Models
{
    /// <summary>
    /// Абстрактный класс содержащий базовые методы и поля для описания геометрических фигур.
    /// Реализует интерфейс IPrintableShape
    /// </summary>
    public abstract class GeometricShape : IPrintableShape
    {
        /// <summary>
        /// Поле содержащее Тип геометрической фигуры.
        /// </summary>
        public abstract string Type { get; }
        /// <summary>
        /// Метод возвращающий площадь геометрической фигуры.
        /// </summary>
        public abstract double GetSquare();
        /// <summary>
        /// Метод возращающий периметр геометрической фигуры.
        /// </summary>
        /// <returns></returns>
        public abstract double GetPerimeter();
        public void PrintPerimeter() 
        {
            Console.WriteLine("Периметр фигуры равен: " + GetPerimeter());
        }
        public void PrintSquare() 
        {
            Console.WriteLine("Площадь фигуры равна: " + GetSquare());
        }
        public void PrintType()
        {
            Console.WriteLine($"Тип фигуры: {Type}");
        }
    }
}
