using System;

namespace GitDemo
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            var bla = new BlaBlaCar();
            var x = new Car();
            bla.AddCar(x);
            var autoService = new AutoService(10);
            var Car = new Car("green");
            Car.AddPassanger();
            Car.StartEngine();
        }
    }
}
