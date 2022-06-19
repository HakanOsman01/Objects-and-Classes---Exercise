using System;
using System.Linq;
using System.Collections.Generic;

namespace _06._Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            string[] vehicleParams = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .ToArray();
            while(vehicleParams[0]!= "End")
            {
                string type = vehicleParams[0];
                string model = vehicleParams[1];
                string color = vehicleParams[2];
                double horsePower = double.Parse(vehicleParams[3]);
                if(type== "car")
                {
                    Car newCar = new Car(model, color, horsePower);
                    cars.Add(newCar);
                }else if(type== "truck")
                {
                    Truck newTruck = new Truck(model, color, horsePower);
                    trucks.Add(newTruck);
                }
                vehicleParams = Console.ReadLine()
           .Split(' ', StringSplitOptions.RemoveEmptyEntries)
           .ToArray();

            }
            string information = Console.ReadLine();
            while(information!="Close the Catalogue")
            {
                bool isCar = GetTypeOfCar(cars, information);
                if (isCar)
                {
                    FindTheInformationAboutCar(cars, information);
                    
                }
                else
                {
                    bool isTruck = GetTypeOfTruck(trucks, information);
                    if (isTruck)
                    {
                        FindTheInformationAboutTruck(trucks, information);
                    }
                    else
                    {
                        information = Console.ReadLine();
                        continue;
                    }
                    
                }
                information = Console.ReadLine();
            }
            double averageCarPower = GetAvaregeHorsePowerCars(cars);
            double avaregeTruckPower = GetAvaregeHorsePowerTrucks(trucks);
           
                Console.WriteLine($"Cars have average horsepower of: {averageCarPower:f2}.");
                Console.WriteLine($"Trucks have average horsepower of: {avaregeTruckPower:f2}.");
            
          

        }
        static bool GetTypeOfCar(List<Car>cars,string information)
        {
            foreach(Car car in cars)
            {
                if (car.Model == information)
                {
                    return true;
                }
            }
            return false;
        }
        static bool GetTypeOfTruck(List<Truck>trucks,string information)
        {
            foreach (Truck truck in trucks)
            {
                if (truck.Model == information)
                {
                    return true;
                }
            }
            return false;
        }
        static void FindTheInformationAboutTruck(List<Truck> trucks, string information)
        {
            foreach (Truck truck in trucks)
            {
                if (truck.Model == information)
                {
                    Console.WriteLine(truck);
                }
            }
        }
        static void FindTheInformationAboutCar(List<Car> cars, string information)
        {
            foreach (Car car in cars)
            {
                if (car.Model == information)
                {
                    Console.WriteLine(car);
                }
            }
        }
        
        static double GetAvaregeHorsePowerCars(List<Car> cars)
        {
            int count = cars.Count;
            double avarageHorsePower = 0.00;
            if (count > 0)
            {
                foreach (Car car in cars)
                {
                    avarageHorsePower += car.HorsePower;
                }
                avarageHorsePower = (avarageHorsePower / (count * 1.00));
            }
           
            return avarageHorsePower;
        }
        static double GetAvaregeHorsePowerTrucks(List<Truck> trucks)
        {
            int count = trucks.Count;
            double avarageHorsePower = 0.00;
            if (count> 0)
            {
                foreach (Truck truck in trucks)
                {
                    avarageHorsePower += truck.HorsePower;
                }
                avarageHorsePower = (avarageHorsePower / (count * 1.00));
            }
            
            return avarageHorsePower;
        }
    }
   
    class Car
    {
        public Car(string model,string color,double horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }

        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
        public override string ToString()
        {
            return $"Type: Car{Environment.NewLine}Model: {this.Model}" +
                $"{Environment.NewLine}Color: {this.Color}" +
                $"{Environment.NewLine}Horsepower: " +
                $"{this.HorsePower}";
        }

    }
    class Truck
    {
        public Truck(string model,string color,double horsePower)
        {
            this.Model = model;
            this.Color = color;
            this.HorsePower = horsePower;
        }
        public string Model { get; set; }
        public string Color { get; set; }
        public double HorsePower { get; set; }
        public override string ToString()
        {
            return $"Type: Truck{Environment.NewLine}" +
                $"Model: {this.Model}" +
                $"{Environment.NewLine}" +
                $"Color: {this.Color}" +
                $"{Environment.NewLine}Horsepower: " +
                $"{this.HorsePower}";
        }


    }

}
