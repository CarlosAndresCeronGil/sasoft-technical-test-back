using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace sasoft_back
{
    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OfferId { get; set; }
        public int Price { get; set; }
        public string OfferStatus { get; set; } = string.Empty;

        public int ProductId { get; set; } = 0;
        [ForeignKey("ProductId")]
        [JsonIgnore]
        public virtual Product? Product { get; set; }

        public int BuyerId { get; set; } = 0;
        [ForeignKey("BuyerId")]
        [JsonIgnore]
        public virtual Buyer? Buyer { get; set; }

    }
}
