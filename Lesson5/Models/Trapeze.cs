namespace Lesson5.Models
{
    /// <summary>
    /// Класс описывающий геометрическую фигуру - трапеция. Дочерний от класса GeometricShape.
    /// </summary>
    internal class Trapeze : GeometricShape
    {
        public override string Type { get; } = "Трапеция";
        /// <summary>
        /// Поле содержащее размер основания трапеции.
        /// </summary>
        private double _basis;

        /// <summary>
        /// Поле содержащее размер верхнего ребра трапеции.
        /// </summary>
        private double _topEdge;

        /// <summary>
        /// Поле содержащее размер левого ребра трапеции.
        /// </summary>
        private double _leftEdge;

        /// <summary>
        /// Поле содержащее размер правого ребра трапеции.
        /// </summary>
        private double _rightEdge;

        /// <summary>
        /// Получить\задать размер основания трапеции. Основание должно быть больше нуля, но меньше суммы остальных трех сторон.
        /// </summary>
        public double Basis
        {
            get => _basis;
            set
            {
                if (value <= 0) throw new ArgumentException("Basis", "Ошибка: Основание трапеции должно быть больше '0'.");
                if (value > (LeftEdge + RightEdge + TopEdge)) throw new ArgumentException("Basis", "Ошибка: Основание трапеции не может быть больше суммы остальных сторон.");
                if (value == TopEdge) throw new ArgumentException("Basis", "Ошибка: Основание трапеции не может быть равно верхнему ребру.");
                _basis = value;
            }
        }

        /// <summary>
        /// Получить\задать размер верхнего ребра трапеции. Верхнее ребро должно быть больше нуля, но меньше суммы остальных трех сторон.
        /// </summary>
        public double TopEdge
        {
            get => _topEdge;
            set
            {
                if (value <= 0) throw new ArgumentException("TopEdge", "Ошибка: Верхнее ребро трапеции должно быть больше '0'.");
                if (value > (LeftEdge + RightEdge + Basis)) throw new ArgumentException("TopEdge", "Ошибка: Верхнее ребро трапеции не может быть больше суммы остальных сторон.");
                if (value == Basis) throw new ArgumentException("TopEdge", "Ошибка: Верхнее ребро трапеции не может быть равно основанию.");
                _topEdge = value;
            }
        }

        /// <summary>
        /// Получить\задать размер левого ребра трапеции. Левое ребро должно быть больше нуля, но меньше суммы остальных трех сторон.
        /// </summary>
        public double LeftEdge
        {
            get => _leftEdge;
            set
            {
                if (value <= 0) throw new ArgumentException("LeftEdge", "Ошибка: Левое ребро трапеции должно быть больше '0'.");
                if (value > (Basis + RightEdge + TopEdge)) throw new ArgumentException("LeftEdge", "Ошибка: Левое ребро трапеции не может быть больше суммы остальных сторон.");
                _leftEdge = value;
            }
        }

        /// <summary>
        /// Получить\задать размер правого ребра трапеции. Правое ребро должно быть больше нуля, но меньше суммы остальных трех сторон.
        /// </summary>
        public double RightEdge
        {
            get => _rightEdge;
            set
            {
                if (value <= 0) throw new ArgumentException("RightEdge", "Ошибка: Правое ребро трапеции должно быть больше '0'.");
                if (value > (Basis + LeftEdge + TopEdge)) throw new ArgumentException("RightEdge", "Ошибка: Правое ребро трапеции не может быть больше суммы остальных сторон.");
                _rightEdge = value;
            }
        }

        /// <summary>
        /// Безопасный метод установки значения основания трапеции. Возвращает true в случае успеха.
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
        /// Безопасный метод установки значения верхнего ребра трапеции. Возвращает true в случае успеха.
        /// </summary>
        public bool TrySetTopEdg(double newTopEdg)
        {
            try
            {
                this.TopEdge = newTopEdg;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Безопасный метод установки значения левого ребра трапеции. Возвращает true в случае успеха.
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
        /// Безопасный метод установки значения правого ребра трапеции. Возвращает true в случае успеха.
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
        /// Инициализирует новый экземпляр класса. basis, topEdge, leftEdge и rightEdge должны быть больше 0. 
        /// Каждый аргумент не может быть больше суммы трех других. Основание и верхнее ребро не могут быть равны.
        /// </summary>
        /// <param name="basis">Основание трапеции. Не может равняться верхнему ребру, должно быть больше 0, но не больше суммы трех других сторон.</param>
        /// <param name="topEdge">Верхнее ребро трапеции. Не может равняться основанию, должно быть больше 0, но не больше суммы трех других сторон.</param>
        /// <param name="leftEdge">Левое ребро трапеции. Должно быть больше 0, но не больше суммы трех других сторон.</param>
        /// <param name="rightEdge">Правое ребро трапеции. Должно быть больше 0, но не больше суммы трех других сторон.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если <paramref name="basis"/>, <paramref name="topEdge"/>, <paramref name="leftEdge"/> или <paramref name="rightEdge"/> не больше 0 или больше суммы трех других параметров.</exception>
        public Trapeze(double basis, double topEdge, double leftEdge, double rightEdge)
        {
            if (basis <= 0 || topEdge <= 0 || leftEdge <= 0 || rightEdge <= 0) throw new ArgumentException("Ошибка: Параметры должны быть больше '0'.");
            if (basis > (leftEdge + rightEdge + topEdge) || topEdge > (basis + rightEdge + leftEdge) || 
                leftEdge > (basis + rightEdge + topEdge) || rightEdge > (leftEdge + basis + topEdge)) throw new ArgumentException("Ошибка: Параметр не должен быть больше суммы трех других параметров.");
            if (basis == topEdge) throw new ArgumentException("Ошибка: Основание и верхнее ребро не могут быть равны.");
            _basis = basis;
            _topEdge = topEdge;
            _leftEdge = leftEdge;
            _rightEdge = rightEdge;
        }

        /// <summary>
        /// Метод вывода в консоль периметра геометрической фигуры с точностью до двух сотых.
        /// </summary>
        public override double GetPerimeter()
        {
            return Math.Round(Basis + LeftEdge + RightEdge + TopEdge, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Метод вывода в консоль площади геометрической фигуры с точностью до двух сотых.
        /// </summary>
        public override double GetSquare()
        {
            var a = (Basis + TopEdge) / 2.0;
            var b = LeftEdge * LeftEdge;
            var c = Basis - TopEdge;
            var d = RightEdge * RightEdge;
            var e = Math.Sqrt(b - Math.Pow((c * c + b - d) / (2.0 * c), 2));
            return Math.Round(a * e, 2, MidpointRounding.AwayFromZero);
        }
    }
}
