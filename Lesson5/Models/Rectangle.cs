namespace Lesson5.Models
{
    /// <summary>
    /// Класс описывающий геометрическую фигуру - прямоугольник. Дочерний от класса GeometricShape.
    /// </summary>
    internal class Rectangle : GeometricShape
    {
        public override string Type { get; } = "Прямоугольник";

        /// <summary>
        /// Поле содержащее длину прямоугольника.
        /// </summary>
        private double _length;

        /// <summary>
        /// Поле содержащее ширину прямоугольника.
        /// </summary>
        private double _width;

        /// <summary>
        /// Получить\задать длину прямоугольник. Длина должна быть больше нуля.
        /// </summary>
        public double Length
        {
            get => _length;
            set
            {
                if (value <= 0) throw new ArgumentException("Length", "Ошибка: Длина прямоугольника должна быть больше '0'.");
                _length = value;
            }
        }

        /// <summary>
        /// Получить\задать ширину прямоугольник. Ширина должна быть больше нуля.
        /// </summary>
        public double Width
        {
            get => _width;
            set
            {
                if (value <= 0) throw new ArgumentException("Width", "Ошибка: Ширина прямоугольника должна быть больше '0'.");
                _width = value;
            }
        }

        /// <summary>
        /// Безопасный метод установки значения длины прямоугольника. Возвращает true в случае успеха.
        /// </summary>
        public bool TrySetLength(double newLength)
        {
            try
            {
                this.Length = newLength;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Безопасный метод установки значения ширины прямоугольника. Возвращает true в случае успеха.
        /// </summary>
        public bool TrySetWidth(double newWidth)
        {
            try
            {
                this.Width = newWidth;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса. length и width должны быть больше 0.
        /// </summary>
        /// <param name="length">Длина прямоугольника. Должна быть больше 0.</param>
        /// <param name="width">Ширина прямоугольника. Должна быть больше 0.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если <paramref name="length"/> или <paramref name="width"/> не больше 0.</exception>
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        /// <summary>
        /// Метод вывода в консоль периметра геометрической фигуры с точностью до двух сотых.
        /// </summary>
        public override double GetPerimeter()
        {
            return Math.Round((Length + Width) * 2.0, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Метод вывода в консоль площади геометрической фигуры с точностью до двух сотых.
        /// </summary>
        public override double GetSquare()
        {
            return Math.Round(Length * Width, 2, MidpointRounding.AwayFromZero);
        }
    }
}
