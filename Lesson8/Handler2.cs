namespace Lesson8
{
    /// <summary>
    /// Класс описывающий вторую функию подписчика делегата класса Counter.
    /// </summary>
    public class Handler2
    {
        /// <summary>
        /// Функция подписчик делегата класса Counter.
        /// </summary>
        /// <param name="count">Значение счетчика, полученное от делегата.</param>
        public virtual void CounterHandler2(int count)
        {
            Console.WriteLine($"Уже {count}, давно пора было начать!");
        }
    }
}
