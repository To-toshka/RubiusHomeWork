using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson8
{
    public class Pong
    {
        public delegate void PongHandler(string message);
        public event PongHandler PongEvent;
        public delegate void PongGetPoinHandler();
        public event PongGetPoinHandler PongGetPoinEvent;

        Random random = new();
        public void MakePass ()
        {
            Thread.Sleep(500);
            PongEvent?.Invoke("Pong");
        }
        protected void TakePoint()
        {
            Thread.Sleep(500);
            PongGetPoinEvent?.Invoke();
        }
        public void PingListener (string message)
        {
            int randomNumber = random.Next(1, 8);
            if (randomNumber == 7)
            {
                Console.WriteLine($"{message} промахнулся! Очко заработал Pong");
                TakePoint();
            }
            else
            {
                Console.WriteLine($"Pong получил {message}");
                MakePass();
            }
        }
        public void GameListener()
        {
            MakePass();
        }
    }
}
