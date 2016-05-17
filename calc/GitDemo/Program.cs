using System;

namespace GitDemo
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            var Car = new Car("green");
            Car.AddPassanger();
            Car.StartEngine();
        }
    }
}
