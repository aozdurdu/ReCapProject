using Core.Utilities.FileOperations;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        //IDataResult<List<CarImageDetailDto>> GetCarImageDetails();
        IDataResult<CarImage> GetById(int Id);
        IDataResult<List<CarImage>> GetCarImagesByCarId(int CarId);
        IResult Add(FileUpload file, string path, CarImage carImage);
        IResult Update(FileUpload file, string path, CarImage carImage);
        IResult Delete(string path, CarImage carIamge);
    }
}
