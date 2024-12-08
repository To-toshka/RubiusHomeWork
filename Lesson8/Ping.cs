namespace Lesson8
{
    public class Ping
    {
        public delegate void PingHandler(string message);
        public event PingHandler PingEvent;
        public delegate void PingGetPoinHandler();
        public event PingGetPoinHandler PingGetPoinEvent;

        Random random = new();
        public void MakePass()
        {
            Thread.Sleep(500);
            PingEvent?.Invoke("Ping");
        }
        protected void TakePoint()
        {
            Thread.Sleep(500);
            PingGetPoinEvent?.Invoke();
        }
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
        public void GameListener ()
        {
            MakePass();
        }
    }
}
