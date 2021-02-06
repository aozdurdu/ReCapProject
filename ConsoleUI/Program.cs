using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());


            Console.WriteLine("--------List of Cars---------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear+ " Daily Price: "+ car.DailyPrice + " Description: " + car.Description);
            }
            
            Console.WriteLine("-----------------------------");

            Console.WriteLine("--------List of Cars where BrandId=1---------");

            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Description: " + car.Description);
            }

            Console.WriteLine("--------List of Cars where ColordId=3---------");

            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Description: " + car.Description);
            }

            Console.WriteLine("--------Add a car to DB---------");

            Car car1 = new Car { CarId = 6, BrandId = 4, ColorId = 3, ModelYear = 2020, DailyPrice = 700, Description = "Luxury Class" };
            Car car2 = new Car { CarId = 7, BrandId = 3, ColorId = 1, ModelYear = 2015, DailyPrice = 300, Description = "E" };
            Car car3 = new Car { CarId = 8, BrandId = 2, ColorId = 2, ModelYear = 2016, DailyPrice = 0, Description = "Economy Class" };
            carManager.Add(car1);
            carManager.Add(car2);
            carManager.Add(car3);

            foreach (var car in carManager.GetCarsByCarId(6))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
            foreach (var car in carManager.GetCarsByCarId(7))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
            foreach (var car in carManager.GetCarsByCarId(8))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
        }
    }
}
