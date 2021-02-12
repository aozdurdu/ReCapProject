using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    // RULE : Do not use new class in business classes. Do injection. Use interface in data access layer to implement business class methods.
    // Remember : The class which implement an interface should use the defined methods in interface and keep its reference. 
    //And in business layer, use contructor if you use an interface.
    
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            if (car.Description.Length <= 2 || car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarDescriptionInvalid);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 10)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetCarsByModelYear(int min, int max)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.ModelYear >= min && p.ModelYear <= max));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }


        /***Before Result structure***
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
        */
    }
}
