namespace Lesson8
{
    /// <summary>
    /// Класс описывающий Ping.
    /// </summary>
    public class Ping
    {
        /// <summary>
        /// Делегат класса Ping передающий сообщение своим подписчикам, для обработки события "Подача Pinga".
        /// </summary>
        /// <param name="message">Сообщение подписчикам содержащее имя класса.</param>
        public delegate void PingHandler(string message);
        /// <summary>
        /// Событие - "Подача Pinga" на основе делегата PingHandler.
        /// </summary>
        public event PingHandler PingEvent;
        /// <summary>
        /// Делегат класса Ping предназначенный для обработки события "Получение очка Ping".
        /// </summary>
        public delegate void PingGetPoinHandler();
        /// <summary>
        /// Событие "Получение очка Ping" на основе делегата PingGetPoinHandler.
        /// </summary>
        public event PingGetPoinHandler PingGetPoinEvent;

        /// <summary>
        /// Объект класса Random, для генерации случайного числа от 1 до 7 (так партии заканчиваются не очень быстро).
        /// </summary>
        Random random = new();

        /// <summary>
        /// Метод вызова подписчиков события "Подача Pinga".
        /// </summary>
        public void MakePass()
        {
            Thread.Sleep(500);
            PingEvent?.Invoke("Ping");
        }
        /// <summary>
        /// Метод вызова подписчиков события "Получение очка Ping".
        /// </summary>
        protected void TakePoint()
        {
            Thread.Sleep(500);
            PingGetPoinEvent?.Invoke();
        }
        /// <summary>
        /// Функция - подписчик делегата класса Pong, для обработки события "Подача Ponga".
        /// </summary>
        /// <param name="message">Сообщение с именем класса Pong</param>
        public void PongListener(string message)
        {
            int randomNumber = random.Next(1, 8);
            if (randomNumber == 7)
            {
                Console.WriteLine($"{message} промахнулся! Очко заработал Ping");
                TakePoint();
            }
            else
            {
                Console.WriteLine($"Ping получил {message}");
                MakePass();
            }
        }
        /// <summary>
        /// Функция - подписчик делегата класса PingPong, для обработки события "Следующая поддача Ping".
        /// </summary>
        public void GameListener ()
        {
            MakePass();
        }
    }
}
