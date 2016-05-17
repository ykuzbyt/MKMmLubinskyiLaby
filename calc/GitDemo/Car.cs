using System;

namespace GitDemo
{
    public class Car
    {
        public Car(string color)
        {
            Color = color;
        }

        public string Color { get; set; }

        private int PassangerCount { get; private set; }

        public void StartEngine()
        {
            Console.WriteLine("Engine started!!!");
        }

        public void AddPassanger()
        {
            ++PassangerCount;
        }
    }
}
