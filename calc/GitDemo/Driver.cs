using System;

namespace GitDemo
{
    public class Driver
    {
        public Driver (string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }
        private Car Car { get; private set; }
        public void BuyCar(Car a)
        {
            Car = a;
            a.AddPassanger(this);
        }
    }
}
