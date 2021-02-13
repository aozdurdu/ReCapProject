using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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
        
        public IResult Add(Rental rental)
        {
            var result = CheckReturnDate(rental.Id);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(result.Message);
        }
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

        public IResult CheckReturnDate(int rentalId)
        {
            var result = _rentalDal.GetRentalDetails(x => x.Id == rentalId && x.ReturnDate == null);
            if (result.Count > 0)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            return new SuccessResult(Messages.RentalAdded);
            
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalsListed);
        }
        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }


    }
}
