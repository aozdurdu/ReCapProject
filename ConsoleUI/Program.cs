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
            CarTest();
            BrandTest();
            ColorTest();
            //CarDetailsTest();          
        }

        /*private static void CarDetailsTest() //For Result structure
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarId + "/" + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }*/

        private static void CarTest() //For Result structure
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("--------List of Cars---------");
            var result0 = carManager.GetAll();

            if (result0.Success == true)
            {
                foreach (var car in result0.Data)
                {
                    Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result0.Message);
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("--------List of Cars where BrandId=2---------");
            var result1 = carManager.GetCarsByBrandId(2);
            if (result1.Success == true)
            {
                foreach (var car in result1.Data)
                {
                    Console.WriteLine("Car ID: " + car.CarId + " Description: " + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result1.Message);
            }
            Console.WriteLine("--------List of Cars where ColordId=3---------");
            var result2 = carManager.GetCarsByColorId(3);
            if (result2.Success == true)
            {
                foreach (var car in result2.Data)
                {
                    Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Description: " + car.Description);
                }
            }
            else
            {
                Console.WriteLine(result2.Message);
            }


            Console.WriteLine("--------Add a car to DB---------");

            Car car1 = new Car { CarId = 6, BrandId = 4, ColorId = 3, ModelYear = 2020, DailyPrice = 700, Description = "Luxury Class" };
            //Car car2 = new Car { CarId = 7, BrandId = 3, ColorId = 1, ModelYear = 2015, DailyPrice = 300, Description = "E" };
            //Car car2 = new Car { CarId = 8, BrandId = 2, ColorId = 2, ModelYear = 2016, DailyPrice = 0, Description = "Economy Class" };
            var result3 = carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);

            if (result3.Success == true)
            {
                Console.WriteLine(result3.Message);

            }
            else
            {
                Console.WriteLine(result3.Message);
            }


            Console.WriteLine("--------Update a car in DB---------");

            car1.BrandId = 3; car1.ColorId = 2; car1.ModelYear = 2019; car1.DailyPrice = 400; car1.Description = "Economy Class";

            var result4 = carManager.Update(car1);

            if (result4.Success == true)
            {
                Console.WriteLine(result4.Message);

            }
            else
            {
                Console.WriteLine(result4.Message);
            }

            Console.WriteLine("--------Delete a car from DB---------");

            var result5 = carManager.Delete(car1);

            if (result5.Success == true)
            {
                Console.WriteLine(result5.Message);

            }
            else
            {
                Console.WriteLine(result5.Message);
            }
        }

    
        
        private static void ColorTest() //For Result structure
        {
            
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("--------List of Colors---------");

            var result0 = colorManager.GetAll();

            if (result0.Success == true)
            {
                foreach (var color in result0.Data)
                {
                    Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result0.Message);
            }
            Console.WriteLine("-----------------------------");

            Console.WriteLine("--------List of Color where ColorId=3---------");


            var result1 = colorManager.GetById(3);
            if (result1.Success == true)
            {
                Console.WriteLine("Color Name of Color Id:3 is : " + result1.Data.ColorName);
            }
            else
            {
                Console.WriteLine(result1.Message);
            }

            Console.WriteLine("--------Add a color to DB---------");

            Color color1 = new Color { ColorId = 6, ColorName = "Magenta" };
            var result2 = colorManager.Add(color1);

            if (result2.Success == true)
            {
                Console.WriteLine(result2.Message);
            }
            else
            {
                Console.WriteLine(result2.Message);
            }

            Console.WriteLine("--------Update a color in DB---------");

            color1.ColorName = "Pink";
            var result3 = colorManager.Update(color1);

            if (result3.Success == true)
            {
                Console.WriteLine(result3.Message);
            }
            else
            {
                Console.WriteLine(result3.Message);
            }

            Console.WriteLine("--------Delete a color from DB---------");

            var result4 = colorManager.Delete(color1);

            if (result4.Success == true)
            {
                Console.WriteLine(result4.Message);
            }
            else
            {
                Console.WriteLine(result4.Message);
            }
        }
        private static void BrandTest() //For Result structure
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("--------List of Brands---------");

            var result0 = brandManager.GetAll();

            if (result0.Success == true)
            {
                foreach (var brand in result0.Data)
                {
                    Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result0.Message);
            }
            Console.WriteLine("-----------------------------");

            Console.WriteLine("--------List of Brand where BrandId=3---------");


            var result1 = brandManager.GetById(3);
            if (result1.Success == true)
            {
                Console.WriteLine("Brand Name of Brand Id:3 is : " + result1.Data.BrandName);
            }
            else
            {
                Console.WriteLine(result1.Message);
            }

            Console.WriteLine("--------Add a brand to DB---------");

            Brand brand1 = new Brand { BrandId = 5, BrandName = "Renault" };
            var result2 = brandManager.Add(brand1);

            if (result2.Success == true)
            {
                Console.WriteLine(result2.Message);
            }
            else
            {
                Console.WriteLine(result2.Message);
            }

            Console.WriteLine("--------Update a brand in DB---------");

            brand1.BrandName = "Opel";
            var result3 = brandManager.Update(brand1);

            if (result3.Success == true)
            {
                Console.WriteLine(result3.Message);
            }
            else
            {
                Console.WriteLine(result3.Message);
            }

            Console.WriteLine("--------Delete a brand from DB---------");

            var result4 = brandManager.Delete(brand1);

            if (result4.Success == true)
            {
                Console.WriteLine(result4.Message);
            }
            else
            {
                Console.WriteLine(result4.Message);
            }
        }
    }
}

 
        //***Before Result structure****
        /*private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


            Console.WriteLine("--------List of Cars---------");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
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
            //Car car2 = new Car { CarId = 7, BrandId = 3, ColorId = 1, ModelYear = 2015, DailyPrice = 300, Description = "E" };
            //Car car3 = new Car { CarId = 8, BrandId = 2, ColorId = 2, ModelYear = 2016, DailyPrice = 0, Description = "Economy Class" };
            carManager.Add(car1);
            //carManager.Add(car2);
            //carManager.Add(car3);

            foreach (var car in carManager.GetById(6))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
            /*foreach (var car in carManager.GetById(7))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
            foreach (var car in carManager.GetById(8))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }

            Console.WriteLine("--------Update a car in DB---------");

            car1.BrandId =3; car1.ColorId = 2; car1.ModelYear = 2019; car1.DailyPrice = 400; car1.Description = "Economy Class";

            carManager.Update(car1);

            foreach (var car in carManager.GetById(6))
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }

            Console.WriteLine("--------Delete a car from DB---------");

            carManager.Delete(car1);

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Car ID: " + car.CarId + " Brand: " + car.BrandId + " Color: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
        }*/
        //***Before Result structure****
        /*private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());


            Console.WriteLine("--------List of Brands---------");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
            }

            Console.WriteLine("-----------------------------");

            Console.WriteLine("--------List of Brand where BrandId=2---------");

            foreach (var brand in brandManager.GetById(2))
            {
                Console.WriteLine("Brand Name of Brand Id:2 is : " + brand.BrandName);
            }

            Console.WriteLine("--------Add a brand to DB---------");

            Brand brand1 = new Brand { BrandId = 5, BrandName = "Toyota"};
            brandManager.Add(brand1);

            foreach (var brand in brandManager.GetById(5))
            {
                Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
            }

            Console.WriteLine("--------Update a brand in DB---------");

            brand1.BrandName = "Volvo";
            brandManager.Update(brand1);

            foreach (var brand in brandManager.GetById(5))
            {
                Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
            }

            Console.WriteLine("--------Delete a brand from DB---------");

            brandManager.Delete(brand1);

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Brand ID: " + brand.BrandId + " Brand Name: " + brand.BrandName);
            }
        }*/

        //***Before Result structure****
        /*private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());


            Console.WriteLine("--------List of Colors---------");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
            }

            Console.WriteLine("-----------------------------");

            Console.WriteLine("--------List of Color where ColorId=3---------");

            foreach (var color in colorManager.GetById(3))
            {
                Console.WriteLine("Color Name of Color Id:3 is : " + color.ColorName);
            }

            Console.WriteLine("--------Add a color to DB---------");

            Color color1 = new Color { ColorId = 6, ColorName = "Magenta" };
            colorManager.Add(color1);

            foreach (var color in colorManager.GetById(6))
            {
                Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
            }

            Console.WriteLine("--------Update a color in DB---------");

            color1.ColorName = "Pink";
            colorManager.Update(color1);

            foreach (var color in colorManager.GetById(6))
            {
                Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
            }

            Console.WriteLine("--------Delete a color from DB---------");

            colorManager.Delete(color1);

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Color ID: " + color.ColorId + " Color Name: " + color.ColorName);
            }
        }*/
        /***Before Result structure****
        private static void CarDetailsTest()
        {
           CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Details: \nBrand Name: " + car.BrandName + "\nColor Name: "+ car.ColorName + "\nDaily Price: " + car.DailyPrice);
            }

        }*/