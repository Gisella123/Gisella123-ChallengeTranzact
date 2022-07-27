using Microsoft.AspNetCore.Mvc;
using Tranzact.Aplication.Contract;
using Tranzact.Aplication.DTO;

namespace Tanzact.Servicio.ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductServiceController : ControllerBase
    {

        private readonly Tranzact.Infraestruture.ILogger _logger;
        private readonly IAplicationServicioProduct _aplicationServicioProduct;
        public ProductServiceController(Tranzact.Infraestruture.ILogger logger,
            IAplicationServicioProduct aplicationServicioProduct)
        {
            _logger = logger;
            _aplicationServicioProduct = aplicationServicioProduct;
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            _logger.Info("Method: Get");
            var result = _aplicationServicioProduct.Get(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpPut("{id}", Name = "UpdateProduct")]
        public IActionResult Update(int id, [FromBody] ProductUpdateDTO productUpdate)
        {
            if (productUpdate == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntityObjectResult(ModelState);
            }

            var result = _aplicationServicioProduct.Update(productUpdate, id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpPost(Name = "CreateProduct")]
        public IActionResult Insert([FromBody]  ProductInsertDTO product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            var result = _aplicationServicioProduct.Insert(product);

            return Ok("Succes");
        }
        
    }
}