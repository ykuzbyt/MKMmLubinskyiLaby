using System;
using System.Collections.Generic;

namespace GitDemo
{
    public class BlaBlaCar
    {
        public BlaBlaCar()
        {
            
        }

        private List<Car> cars;

        public void AddCar(Car c)
        {
            if (!cars.Contains(c))
            cars.Add(c);
        }
    }
}

