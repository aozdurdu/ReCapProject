using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
           if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("New car added to DB");
            }
           else
            {
                Console.WriteLine("Not added. Car description should be more than 2 characters and car daily price should be bigger than 0");
            }

        }

        public List<Car> GetAll()
        {
            //Business codes in here
            
            return _carDal.GetAll();
        }

       public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(p => p.BrandId==brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(p => p.ColorId == colorId);
        }

        public List<Car> GetById(int Id)
        {
            return _carDal.GetAll(p => p.CarId == Id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Car is updated in DB");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Car is deleted from DB");
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
