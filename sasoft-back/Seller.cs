using System.ComponentModel.DataAnnotations;

namespace sasoft_back
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        //public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
        public virtual List<Product>? Products { get; set; }

    }

    public class SellerWithProducts
    {
        [Key]
        public int SellerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public virtual List<Product>? Products { get; set; }

    }
}
