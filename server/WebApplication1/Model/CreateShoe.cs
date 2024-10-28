namespace WebApplication1.Model
{
    public class CreateShoe
    {
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Stock { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
    }
}
