using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sasoft_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Bicycle", SellerId = 200 },
                new Product { ProductId = 2, Name = "Helmet" },
                new Product { ProductId = 3, Name = "Tv"}
        };
        private readonly DataContext context;

        public ProductController (DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await context.Products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return BadRequest("Product not found.");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok(await context.Products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product request)
        {
            var product = products.Find(product => product.ProductId == request.ProductId);
            if (product == null)
            {
                return BadRequest("Product not found.");
            }
            product.Name = request.Name;
            product.Description = request.Description;

            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> Delete(int id)
        {
            var product = products.Find(product => product.ProductId == id);
            if (product == null)
            {
                return BadRequest("Product not found.");
            }
            products.Remove(product);
            return Ok(product);
        }
    }
}
