namespace WebApplication1.Services
{
    public interface IShortenUrlServices
    {
        public const int NumberOfCharactersInShortUrl = 7;
        protected const string allowedchars = "";
        Task<string> CreateShortenUrlAsync(string longUrl);
    }
}
