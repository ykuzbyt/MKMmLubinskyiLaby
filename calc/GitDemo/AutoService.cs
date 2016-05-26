using System;
using System.Collections.Generic;

namespace GitDemo
{
    public class AutoService
    {
        public AutoService (int numberOfEmployees)
        {
            NumberOfEmployees = numberOfEmployees;
        }
        public List<Car> Cars { get; private set; }

        public void AddCarToService(Car car)
        {
            if (car == null)
                throw new ArgumentNullException ("car");
            Cars.Add(car); 
        }

        public int NumberOfEmployees { get; private set; }
    }
}

