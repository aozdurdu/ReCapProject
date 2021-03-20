using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(
                IsRentable(rental));
            if (result != null)
            {
                return result;
            }
            rental.RentDate = DateTime.Now;
            _rentalDal.Add(rental);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
        public IResult Delete(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == rentalId));
        }

        public IDataResult<Rental> GetLastByCarId(int carId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.GetAll(r => r.CarId == carId).LastOrDefault());
        }

        public IDataResult<List<Rental>> GetAllByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CustomerId == customerId));
        }

        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
        }

        public IResult IsDelivered(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data.LastOrDefault();
            if (result == null || result.ReturnDate != default)
                return new SuccessResult();
            return new ErrorResult();
        }

        public IResult IsRentable(Rental rental)
        {
            var result = this.GetAllByCarId(rental.CarId).Data.LastOrDefault();
            if (IsDelivered(rental).Success || (rental.RentStartDate > result.RentEndDate && rental.RentStartDate >= DateTime.Now))
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        public IDataResult<List<Rental>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.CarId == carId));
        }
    }
}
