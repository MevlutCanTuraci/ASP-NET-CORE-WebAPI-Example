using Microsoft.AspNetCore.Mvc;
using myAPI.Models;

namespace myAPI.Controllers
{
    [Route("/logithink/[controller]")]
    public class ProductsController : Controller
    {
        private static List<ProductsModels> Products = new List<ProductsModels>(new[]
        {
            new ProductsModels() {Id = 1, Name = "tea", Price = "65"},
            new ProductsModels() {Id = 2, Name = "aa", Price = "20"},
            new ProductsModels() {Id = 3, Name = "bb", Price = "95"},
        });


        [HttpGet]
        public IEnumerable<ProductsModels> Get() => Products;


        [HttpGet("{id}")]
        public IActionResult GetNew(int id)
        {
            var product = Products.SingleOrDefault(p => p.Id.Equals(id));

            if (product == null)
            {
                return NotFound();
            }

            else return Ok(product);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var status = Products.Remove(Products.SingleOrDefault(p => p.Id == id));

            if (status)
                return Ok(new { Message = "Success" });

            else return NotFound("Error baby");
        }


        [HttpGet("GetMyConfig")]
        public ContentResult Deneme()
        {
            return Content("Selam, burası sana config bilgilerini dönecektir.");
        }


        [HttpGet("GetDeneme")]
        public string GetDeneme()
        {
            return "Deneme string aga";
        }



        [HttpPost]
        public IActionResult Post(ProductsModels product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Random rdn = new Random();

            product.Id = rdn.Next(1, 255);
            Products.Add(product);


            return CreatedAtAction(nameof(Get), new {id = product.Id}, product);
        }


        [HttpPost("AddProduct")]
        public IActionResult PostBody([FromBody] ProductsModels product) => Post(product);


    }
}
