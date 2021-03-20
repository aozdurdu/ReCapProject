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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentDbContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (CarRentDbContext context = new CarRentDbContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars
                             on rent.CarId equals car.CarId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join customer in context.Customers
                             on rent.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             select new RentalDetailDto
                             {
                                 RentalId = rent.Id,
                                 CustomerName = user.FirstName + user.LastName,
                                 RentDate = rent.RentDate,
                                 RentStartDate = rent.RentStartDate,
                                 RentEndDate = rent.RentEndDate,
                                 ReturnDate = rent.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
