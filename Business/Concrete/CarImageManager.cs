using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileOperations;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
          }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(FileUpload file, string path, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImageCountLimitReached(carImage.CarId));
            
            if (result != null)
            {
                return result;
            }

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string newImageFileName = RenameFileToGuid(file);

            carImage.ImagePath = newImageFileName;
            carImage.Date = DateTime.Now;

            UploadImage(file, path, newImageFileName);

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }


        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(FileUpload file, string path, CarImage carImage)
        {
            var carImageToUpdate = _carImageDal.Get(p => p.Id == carImage.Id);
            DeleteImage(path + carImageToUpdate.ImagePath);
            
            string newImageFileName = RenameFileToGuid(file);
            carImage.ImagePath = newImageFileName;
            carImage.Date = DateTime.Now;
            UploadImage(file, path, newImageFileName);

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }
        public IResult Delete(string path, CarImage carImage)
        {
            var carImageToDelete = _carImageDal.Get(p => p.Id == carImage.Id);
            DeleteImage(path + carImageToDelete.ImagePath);
            
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == carImageId), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetCarImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId), Messages.CarImagesListed);
        }

        /*public IDataResult<List<CarImageDetailDto>> GetCarImageDetails()
        {
            return new SuccessDataResult<List<CarImageDetailDto>>(_carImageDal.GetCarImageDetails());
        }*/

        private void UploadImage(FileUpload file, string path, string newImageFileName)
        {
            using (FileStream fileStream = System.IO.File.Create(path + newImageFileName))
            {
                file.files.CopyTo(fileStream);
                fileStream.Flush();
            }
        }
        private string RenameFileToGuid(FileUpload file)
        {
            string[] fileNameSplit = file.files.FileName.Split('.');
            var extensionOfFile = "." + fileNameSplit[fileNameSplit.Length - 1];
            var result =
                DateTime.Now.Day.ToString() + "_" +
                DateTime.Now.Month.ToString() + "_" +
                DateTime.Now.Year.ToString() + "_" +
                Guid.NewGuid().ToString() + extensionOfFile;
            return result;
        }

        private IResult CheckCarImageCountLimitReached(int carId)
        {
            var result = _carImageDal.GetAll(p => p.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.MaxCarImageCountLimit);
            }
            return new SuccessResult();
        }

        private static void DeleteImage(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

    }
}
