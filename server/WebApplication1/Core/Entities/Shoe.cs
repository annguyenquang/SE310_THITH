namespace WebApplication1.Core.Entities
{
    public class Shoe
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Stock { get; set; }
        public string PictureUrl { get; set; } = string.Empty;
    }
}
