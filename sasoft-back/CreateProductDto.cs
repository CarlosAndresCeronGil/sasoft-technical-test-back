namespace sasoft_back
{
    public class CreateProductDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SellerId { get; set; } = 1;
    }
}
