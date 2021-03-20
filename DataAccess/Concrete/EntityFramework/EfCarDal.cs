using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentDbContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetailsByFilter(CarDetailFilterDto filterDto)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                var filterExpression = GetFilterExpression(filterDto);
                var result = from car in filterExpression == null ? context.Cars : context.Cars.Where(filterExpression)
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             select new CarDetailDto
                             {
                                 CarId = car.CarId,
                                 BrandName = brand.BrandName,
                                 Description = car.Description,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
    }
}
