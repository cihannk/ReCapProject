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
            string path = @"C:\Users\Cihan\source\repos\ReCapProject\Entities\EntityAssets\CarImage\";
            carImage.ImagePath = path + carImage.Id;
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
    }
}
