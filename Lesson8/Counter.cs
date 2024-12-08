using System.Runtime.InteropServices.Marshalling;

namespace Lesson8
{
    public class Counter
    {
        protected delegate void CounterHandler(int counter);
        protected event CounterHandler Handler;
        private int _counter = 0;
        protected virtual void CallHendler (int counter)
        {
            Handler?.Invoke(counter);
        }
        Handler1 handler1 = new();
        Handler2 handler2 = new();
        public void StartCount()
        {
            Handler += handler1.CounterHandler1;
            Handler += handler2.CounterHandler2;

            while (_counter <= 100) 
            {
                Console.WriteLine(_counter);
                Thread.Sleep(100);                
                if (_counter == 33)
                {
                    CallHendler(_counter);
                }
                _counter++;
            }
        }

    }
}
