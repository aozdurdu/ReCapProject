using Core.Utilities.FileOperations;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";

            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getcarimagesbycarid")]
        public IActionResult GetCarImagesByCarId(int carId)
        {
            var result = _carImageService.GetCarImagesByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] FileUpload file)
        {
            CarImage _carImage = JsonConvert.DeserializeObject<CarImage>(file.carImages);
            if (file.files.Length > 0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";

                var result = _carImageService.Add(file, path, _carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
        }
        [HttpPost("update")]
        public IActionResult Update([FromForm] FileUpload file)
        {
            CarImage _carImage = JsonConvert.DeserializeObject<CarImage>(file.carImages);
            if (file.files.Length > 0)
            {
                string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                var result = _carImageService.Update(file, path, _carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest();
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var result = _carImageService.Delete(path, carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
