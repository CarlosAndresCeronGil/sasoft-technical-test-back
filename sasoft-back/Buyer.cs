using System.ComponentModel.DataAnnotations;

namespace sasoft_back
{
    public class Buyer
    {
        [Key]
        public int BuyerId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public virtual ICollection<Offer> Offer { get; set; }
    }
}
