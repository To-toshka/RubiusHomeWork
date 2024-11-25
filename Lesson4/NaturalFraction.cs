namespace Lesson4
{
    internal class NaturalFraction
    {
        private int _numerator;
        private int _denominator;
        public bool IsNegatice { get; set; }

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
            Numerator = (numerator < 0) ? -numerator : numerator;
            Denominator = (denominator < 0) ? -denominator : denominator;
            IsNegatice = (numerator < 0) ^ (denominator < 0);
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
            
            Numerator = (integerPart < 0) ? -integerPart * denominator + numerator : integerPart * denominator + numerator;
            Denominator = denominator;
            IsNegatice = integerPart < 0 ? true : false;
        }
        #region function
        public override string ToString()
        {
            if (Numerator == 0) return "0";

            string indication = IsNegatice ? "-" : "";
            int integerPart = Numerator / Denominator;
            int newNumerator = Numerator % Denominator; 
            
            if (newNumerator == 0) return $"{indication}{integerPart}";

            string stringIntegerPart = integerPart > 0 ? $"{integerPart} целых " : "";
            int denominator = Denominator;
            var resullt = NaturalFractionFormatConverter(newNumerator, denominator);

            return $"{indication}{stringIntegerPart}{resullt.Item1}/{resullt.Item2}";
        }
        /// <summary>
        /// Функция сокращения дроби.
        /// </summary>
        private static (int, int) NaturalFractionFormatConverter(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть равен нулю.");

            int largestCommonDivisor = LargestCommonDivisor(numerator, denominator);

            int resultNumerator = numerator / largestCommonDivisor;
            int resultDenominator = denominator / largestCommonDivisor;

            return (resultNumerator, resultDenominator);
        }
        /// <summary>
        /// Функция нахождения наибольшего общего знаменателя.
        /// </summary>
        private static int LargestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return Math.Abs(a);
        }
        #endregion
        #region operators
        public static NaturalFraction operator + (NaturalFraction a, NaturalFraction b)
        {
            int newNumerator = ((a.IsNegatice ? -a.Numerator : a.Numerator) * b.Denominator) 
                + ((b.IsNegatice ? -b.Numerator : b.Numerator) * a.Denominator);
            int newDenominator = (a.Denominator * b.Denominator);
            NaturalFraction result = new(newNumerator, newDenominator);
            return result;
        }
        public static NaturalFraction operator - (NaturalFraction a, NaturalFraction b)
        {
            int newNumerator = ((a.IsNegatice ? -a.Numerator : a.Numerator) * b.Denominator) 
                - ((b.IsNegatice ? -b.Numerator : b.Numerator) * a.Denominator);
            int newDenominator = (a.Denominator * b.Denominator);
            NaturalFraction result = new(newNumerator, newDenominator);
            return result;
        }
        public static NaturalFraction operator * (NaturalFraction a, NaturalFraction b)
        {
            int newNumerator = ((a.IsNegatice ? -a.Numerator : a.Numerator)
                * (b.IsNegatice ? -b.Numerator : b.Numerator));
            int newDenominator = (a.Denominator * b.Denominator);
            NaturalFraction result = new(newNumerator, newDenominator);
            return result;
        }
        public static NaturalFraction operator / (NaturalFraction a, NaturalFraction b)
        {
            int newNumerator = ((a.IsNegatice ? -a.Numerator : a.Numerator) * b.Denominator);
            int newDenominator = (a.Denominator * b.Numerator);
            NaturalFraction result = new(newNumerator, newDenominator);
            return result;
        }
        public static implicit operator float(NaturalFraction a) {
            float floatNumerator = (float) (a.IsNegatice ? -a.Numerator : a.Numerator);
            float floatDenominator = (float)(a.Denominator);
            float floatResult = floatNumerator / floatDenominator;
            return floatResult;
        }
        public static implicit operator double(NaturalFraction a)
        {
            double doubleNumerator = (double)(a.IsNegatice ? -a.Numerator : a.Numerator);
            double doubleDenominator = (double)(a.Denominator);
            double doubleResult = doubleNumerator / doubleDenominator;
            return doubleResult;

        }
        #endregion
    }
}
