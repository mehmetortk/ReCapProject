using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {// loosely coupled - gevşek bağlılık bir bağlılık var lakin abstract'a bağlı
        private ICarService _carService;
        //IoC Container Inversion of Control yani değişimin controlü IoC bir depo gibidir ve içinde IcarService için
        //CarManager EfCarDal gibi değerler new lenmiş halde duru IoC ile ICarService ihtiyacı olanı kullanır.
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]
        //getbyid için link kısmında örn http//xxxx/api/cars/getbyid?id=1 dersek id 1 olanlar gelir hata vermemesi için
        //[HttpGet ("x")] operasyonlara isim verilir örn getbyid, getall gibi
        public IActionResult Get()
        {// dependecy chain -- ICarService -Carmanager'a ,Carmanager is EfCarDal'a ihtiyaç duyuyor bağımlılık zinciri
            var result = _carService.GetAll();
            if (result.Success)
            {//postmande görülebileceği üzere get requestlerin başarılı olması durumunda 200 OK var burada IActionResult
                //tipinde get kullanarak result true ise bize Ok result.data dönecek
                return Ok(result);
            }
            //bad request başarız olursa istek çalışır
            return BadRequest(result);

        }
        
        //post veri yüklemeyi sağlar getirmeyi değil post man'da post kısmına proplar aracılıgı ile veri gönderilir.
        [HttpPost]// silme ve güncelleme işlemlerinde de post kullanılır genelde
        public IActionResult Post(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
