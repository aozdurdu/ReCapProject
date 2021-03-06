﻿using Core.DataAccess.EntityFramework;
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
        public List<CarDetailDto> GetAllCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                var result = from p in context.Cars
                             join c in context.Brands
                             on p.BrandId equals c.BrandId
                             join cl in context.Colors
                             on p.ColorId equals cl.ColorId
                             select new CarDetailDto
                             {
                                 CarId = p.CarId,
                                 ModelYear = p.ModelYear,
                                 Description = p.Description,
                                 BrandName = c.BrandName,
                                 ColorName = cl.ColorName,
                                 DailyPrice = p.DailyPrice
                                 
                             };
                return result.ToList();
            }
        }
    }
}
