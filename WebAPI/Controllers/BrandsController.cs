using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private IBrandService _brandService;
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet ("brandid")]
        public IActionResult GetByBrandId(int id)
        {
            var result = _brandService.GetCarsByBrandId(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
