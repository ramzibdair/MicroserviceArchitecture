namespace WebApplication1.Entities
{
    public class ShortenUrl
    {
        public Guid Id { get; set; }
        public string ShortUrl { get; set; } = string.Empty;
        public string LongUrl { get; set; } = String.Empty;
        public DateTime CraetedOnUtc { get; set; } 
    }
}
