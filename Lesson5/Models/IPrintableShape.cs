namespace Lesson5.Models
{
    /// <summary>
    /// Интерфейс содержащий методы реализующие вывод в консоль площади, периметра и типа геометрической фигуры.
    /// </summary>
    public interface IPrintableShape
    {
        /// <summary>
        /// Метод вывода типа геометрической фигуры в консоль.
        /// </summary>
        void PrintType();
        /// <summary>
        /// Метод вывода площади геометрической фигуры в консоль.
        /// </summary>
        void PrintSquare();
        /// <summary>
        /// Метод вывода периметра геометрической фигуры в консоль.
        /// </summary>
        void PrintPerimeter();
    }
}
