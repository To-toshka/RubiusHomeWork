namespace Lesson4
{
    internal class NaturalFraction
    {
        private int _numerator;
        private int _denominator;

        public int Numerator
        {
            get { return _numerator; }
            set { _numerator = value; }
        }
        public int Denominator
        {
            get { return _denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentOutOfRangeException ("denominator", "Знаминатель дроби не может равняться \"0\"");
                }
                _denominator = value;
            }
        }


        /// <summary>
        /// Инициализирует новый экземпляр класса, denominator не может равняться 0.
        /// </summary>
        /// <param name="numerator">Начальное значение числителя.</param>
        /// <param name="denominator">Начальное значение знаменателя, которое не может равняться 0.</param>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если <paramref name="denominator"/> равен 0.</exception>
        public NaturalFraction (int numerator, int denominator)
        {
            Numerator = numerator;
            Denominator = denominator;
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса. Знак дроби определяется по integerPart. 
        /// numerator не должен быть меньше 0, denominator должен быть больше 0.
        /// </summary>
        /// <param name="integerPart">Начальное значение целой части дроби.</param>
        /// <param name="numerator">Начальное значение числителя, не может быть меньше 0.</param>
        /// <param name="denominator">Начальное значение знаменателя, которое должно быть больше 0.</param>
        /// <exception cref="ArgumentOutOfRangeException">Выбрасывается, если <paramref name="numerator"/> меньше 0 или <paramref name="denominator"/> не больше 0.</exception>
        public NaturalFraction(int integerPart, int numerator, int denominator)
        {
            if (numerator < 0 ) throw new ArgumentOutOfRangeException("numerator", "Числитель дроби не может быть отрицательным при использовании данного конструктора.");
            if (denominator < 0) throw new ArgumentOutOfRangeException("denominator", "Знаменатель дроби не может быть отрицательным при использовании данного конструктора.");
            
            Numerator = integerPart < 0 ? integerPart * denominator - numerator : integerPart * denominator + numerator;
            Denominator = denominator;
        }

        #region operators
        public static NaturalFraction operator + (NaturalFraction a, NaturalFraction b)
        {
            int newNumerator = (a.Numerator * b.Denominator) + (b.Numerator * a.Denominator);
            int newDenominator = (a.Denominator * b.Denominator);
            NaturalFraction result = new(newNumerator, newDenominator);
            return result;
        }
        public static NaturalFraction operator - (NaturalFraction a, NaturalFraction b)
        {
            int newNumerator = (a.Numerator * b.Denominator) - (b.Numerator * a.Denominator);
            int newDenominator = (a.Denominator * b.Denominator);
            NaturalFraction result = new(newNumerator, newDenominator);
            return result;
        }
        public static NaturalFraction operator * (NaturalFraction a, NaturalFraction b)
        {
            int newNumerator = (a.Numerator * b.Numerator);
            int newDenominator = (a.Denominator * b.Denominator);
            NaturalFraction result = new(newNumerator, newDenominator);
            return result;
        }
        public static NaturalFraction operator / (NaturalFraction a, NaturalFraction b)
        {
            int newNumerator = (a.Numerator * b.Denominator);
            int newDenominator = (a.Denominator * b.Numerator);
            NaturalFraction result = new(newNumerator, newDenominator);
            return result;
        }
        #endregion
    }
}
