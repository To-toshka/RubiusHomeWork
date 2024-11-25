namespace Lesson5.Models
{
    /// <summary>
    /// Класс описывающий геометрическую фигуру - круг. Дочерний от класса GeometricShape.
    /// </summary>
    internal class Circle : GeometricShape
    {
        public override string Type { get; } = "Круг";

        /// <summary>
        /// Поле содержащее радиус круга.
        /// </summary>
        private double _radius;

        /// <summary>
        /// Число Пи с точностью до сотых.
        /// </summary>
        const double _numberPi = 3.14;

        /// <summary>
        /// Получить\задать радиус круга. Радиус должен быть больше нуля.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0) throw new ArgumentException("Radius", "Ошибка: Радиус круга должен быть больше '0'.");
                _radius = value;
            }
        }

        /// <summary>
        /// Безопасный метод установки значения радиуса круга. Возвращает true в случае успеха.
        /// </summary>
        public bool TrySetRadius(double newRadius)
        {
            try
            {
                this.Radius = newRadius;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса. radius должен быть больше 0.
        /// </summary>
        /// <param name="radius">Радиус круга. Должен быть больше 0.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если <paramref name="radius"/> не больше 0.</exception>
        public Circle (double radius)
        {
            Radius = radius;
        }

        /// <summary>
        /// Метод вывода в консоль периметра геометрической фигуры с точностью до двух сотых.
        /// </summary>
        public override double GetPerimeter()
        {
            return Math.Round(2.0 * _numberPi * Radius, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Метод вывода в консоль площади геометрической фигуры с точностью до двух сотых.
        /// </summary>
        public override double GetSquare()
        {
            return Math.Round(_numberPi * Radius * Radius, 2, MidpointRounding.AwayFromZero);
        }
    }
}
