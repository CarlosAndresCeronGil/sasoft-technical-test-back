using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sasoft_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private static List<Seller> sellerList = new List<Seller>
        {
            /*
            new Seller { SellerId = 200, FirstName = "Miguel", LastName = "Rodriguez", Email = "MiguelR@email.com" },
            new Seller { SellerId = 201, FirstName = "David", LastName = "Velasquez", Email = "DavidV@email.com" },
            new Seller { SellerId = 202, FirstName = "Maria", LastName = "Hernandez", Email = "MariaH@email.com" },
            */
        };
        private readonly DataContext context;

        public SellerController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Seller>>> Get()
        {
            //return Ok(await context.Sellers.ToListAsync());
            var sellerWithProducts = context.Sellers.Select(seller => new SellerWithProducts()
            {
                SellerId = seller.SellerId,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Email = seller.Email,
                Products = seller.Products.Select(n => n).ToList()
            }).ToList();

            return Ok(sellerWithProducts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Seller>>> Get(int id)
        {
            /*var seller = await context.Sellers.FindAsync(id);
            if (seller == null)
            {
                return BadRequest("Seller not found.");
            }
            return Ok(seller);*/
            var sellerWithProducts = context.Sellers.Where(n => n.SellerId == id).Select(seller => new SellerWithProducts()
            {
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                Email = seller.Email,
                Products = seller.Products.Select(n => n).ToList()
            }).FirstOrDefault();

            return Ok(sellerWithProducts);
        }

        [HttpPost]
        public async Task<ActionResult<List<Seller>>> AddProduct(Seller seller)
        {
            context.Sellers.Add(seller);
            await context.SaveChangesAsync();

            return Ok(await context.Sellers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Seller>>> UpdateProduct(Seller request)
        {
            var dbSeller = await context.Sellers.FindAsync(request.SellerId);
            if (dbSeller == null)
            {
                return BadRequest("Seller not found.");
            }
            dbSeller.FirstName = request.FirstName;
            dbSeller.LastName = request.LastName;
            dbSeller.Email = request.Email;

            await context.SaveChangesAsync();

            return Ok(await context.Sellers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Seller>>> Delete(int id)
        {
            var dbSeller = await context.Sellers.FindAsync(id);
            if (dbSeller == null)
            {
                return BadRequest("Seller not found.");
            }
            context.Sellers.Remove(dbSeller);
            await context.SaveChangesAsync();

            return Ok(await context.Sellers.ToListAsync());
        }
    }
}
