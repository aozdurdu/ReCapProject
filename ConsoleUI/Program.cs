using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());


            Console.WriteLine("--------List of Cars---------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear+ " Daily Price: "+ car.DailyPrice + " Description: " + car.Description);
            }
            
            Console.WriteLine("-----------------------------");
        }
    }
}
