using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]//bir classla ilgili bilgi verme onu imzalama yöntemine attribute denir.
    //Ioc değişimin kontrolü
    public class ProductsController : ControllerBase
    {//loosely coupled bir bağımlılık var ama soyuta bağımlılık var. managerımızı değiştirirsek herhangi bir problemle karşılaşmayız
        //naming convention
        IProductService _productService;//bunu field yapıyim constructor dan gelen referansı _productService e ata

        public ProductsController(IProductService productService)//bu yapı contollera sen IProductService bağımlısısın diyor.
        //constructor da bana bir tane manager ver IProductService manager ver demek çünkü managerın referansını tutar
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get()
        {
            
           var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if(result.Success)
            { return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
