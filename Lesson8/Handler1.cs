namespace Lesson8
{
    /// <summary>
    /// Класс описывающий первую функию подписчика делегата класса Counter.
    /// </summary>
    public class Handler1
    {
        /// <summary>
        /// Функция подписчик делегата класса Counter.
        /// </summary>
        /// <param name="count"> Значение счетчика, полученное от делегата.</param>
        public virtual void CounterHandler1 (int count)
        {
            Console.WriteLine($"Пора действовать, ведь уже {count}");
        }
    }
}
