using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageController : ControllerBase
    {
        ICarImageService _carImageManager;
        public CarImageController(ICarImageService carImageManager)
        {
            _carImageManager = carImageManager;
        }
        [HttpPost("add")]
        public IActionResult Add(CarImage carImage)
        {
            
            IResult result =  _carImageManager.Add(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageManager.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallimages")]
        public IActionResult GetAllImages(int carId)
        {
            var result = _carImageManager.GetCarImages(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("get")]
        public IActionResult GetImage(int carid)
        {
            var paths = _carImageManager.GetCarImages(carid);
            Byte[] b = System.IO.File.ReadAllBytes(paths.Data[0]+".jpg");
            return File(b, "image/jpeg");
        }
    }
}
