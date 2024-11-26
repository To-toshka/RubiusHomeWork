namespace Lesson5.Models
{
    /// <summary>
    /// Класс описывающий геометрическую фигуру - треугольник. Дочерний от класса GeometricShape.
    /// </summary>
    internal class Triangle : GeometricShape
    {
        public override string Type { get; } = "Треугольник";

        /// <summary>
        /// Поле содержащее размер основания треугольника.
        /// </summary>
        private double _basis;

        /// <summary>
        /// Поле содержащее размер левого ребра треугольника.
        /// </summary>
        private double _leftEdge;

        /// <summary>
        /// Поле содержащее размер правого ребра треугольника.
        /// </summary>
        private double _rightEdge;

        /// <summary>
        /// Получить\задать размер основания треугольника. Основание должно быть больше нуля, но меньше суммы остальных двух сторон.
        /// </summary>
        public double Basis
        {
            get => _basis;
            set
            {
                if (value <= 0) throw new ArgumentException("Basis", "Ошибка: Основание треугольника должно быть больше '0'.");
                if (value > (LeftEdge + RightEdge)) throw new ArgumentException("Basis", "Ошибка: Основание треугольника не может быть больше суммы остальных сторон.");
                _basis = value;
            }
        }

        /// <summary>
        /// Получить\задать размер левого ребра треугольника. Левое ребро должно быть больше нуля, но меньше суммы остальных двух сторон.
        /// </summary>
        public double LeftEdge
        {
            get => _leftEdge;
            set
            {
                if (value <= 0) throw new ArgumentException("LeftEdge", "Ошибка: Левое ребро треугольника должно быть больше '0'.");
                if (value > (Basis + RightEdge)) throw new ArgumentException("LeftEdge", "Ошибка: Левое ребро треугольника не может быть больше суммы остальных сторон.");
                _leftEdge = value;
            }
        }

        /// <summary>
        /// Получить\задать размер правого ребра треугольника. Правое ребро должно быть больше нуля, но меньше суммы остальных двух сторон.
        /// </summary>
        public double RightEdge
        {
            get => _rightEdge;
            set
            {
                if (value <= 0) throw new ArgumentException("RightEdge", "Ошибка: Правое ребро треугольника должно быть больше '0'.");
                if (value > (Basis + LeftEdge)) throw new ArgumentException("RightEdge", "Ошибка: Правое ребро треугольника не может быть больше суммы остальных сторон.");
                _rightEdge = value;
            }
        }

        /// <summary>
        /// Безопасный метод установки значения основания треугольника. Возвращает true в случае успеха.
        /// </summary>
        public bool TrySetBasis(double newBasis)
        {
            try
            {
                this.Basis = newBasis;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Безопасный метод установки значения левого ребра треугольника. Возвращает true в случае успеха.
        /// </summary>
        public bool TrySetLeftEdg(double newLeftEdg)
        {
            try
            {
                this.LeftEdge = newLeftEdg;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Безопасный метод установки значения правого ребра треугольника. Возвращает true в случае успеха.
        /// </summary>
        public bool TrySetRightEdge(double newRightEdge)
        {
            try
            {
                this.RightEdge = newRightEdge;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса. basis, leftEdge и rightEdge должны быть больше 0. 
        /// Каждый аргумент не может быть больше суммы двух других.
        /// </summary>
        /// <param name="basis">Основание треугольника. Должно быть больше 0, но не больше суммы двух других сторон.</param>
        /// <param name="leftEdge">Левое ребро треугольника. Должно быть больше 0, но не больше суммы двух других сторон.</param>
        /// <param name="rightEdge">Правое ребро треугольника. Должно быть больше 0, но не больше суммы двух других сторон.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если <paramref name="basis"/>, <paramref name="leftEdge"/> или <paramref name="rightEdge"/> не больше 0 или больше суммы двух других параметров.</exception>
        public Triangle(double basis, double leftEdge, double rightEdge)
        {
            if (basis <= 0 || leftEdge <= 0 || rightEdge <= 0) throw new ArgumentException("Ошибка: Параметры должны быть больше '0'.");
            if (basis > (leftEdge + rightEdge) || leftEdge > (basis + rightEdge) || rightEdge > (leftEdge + basis)) throw new ArgumentException("Ошибка: Параметр не должен быть больше суммы двух других параметров.");
            _basis = basis;
            _leftEdge = leftEdge;
            _rightEdge = rightEdge;
        }

        /// <summary>
        /// Метод вывода в консоль периметра геометрической фигуры с точностью до двух сотых.
        /// </summary>
        public override double GetPerimeter()
        {
            return Math.Round(Basis + LeftEdge + RightEdge, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Метод вывода в консоль площади геометрической фигуры с точностью до двух сотых.
        /// </summary>
        public override double GetSquare()
        {
            var p = (Basis + LeftEdge + RightEdge) / 2.0;
            var square = Math.Sqrt(p * (p - Basis) * (p - LeftEdge) * (p - RightEdge));
            return Math.Round(square, 2, MidpointRounding.AwayFromZero);
        }
    }
}
