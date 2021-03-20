using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int rentalId);
        IDataResult<Rental> GetLastByCarId(int carId);
        IDataResult<List<Rental>> GetAllByCustomerId(int customerId);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
        IResult IsDelivered(Rental rental);
        IResult IsRentable(Rental rental);
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
