using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.Services
{
    public class ShortenUrlServices : IShortenUrlServices
    {

        private readonly Random _randomrandom = new Random();
        private readonly ApplicationDBContext _dbontext ;

        public ShortenUrlServices(ApplicationDBContext dbontext)
        {
            _dbontext = dbontext;
        }

        public async Task<string> CreateShortenUrlAsync(string longUrl)
        {
            while(true){
                string shortUrl = string.Empty;
                int index = 0;
                for (int i = 0; i < IShortenUrlServices.NumberOfCharactersInShortUrl; i++)
                {
                    index = _randomrandom.Next(0, IShortenUrlServices.allowedchars.Length);
                    shortUrl += IShortenUrlServices.allowedchars[index];
                }
                if (! await _dbontext.ShortenUrls.AnyAsync(s => s.ShortUrl == shortUrl))
                {
                   await _dbontext.ShortenUrls.AddAsync(
                        new ShortenUrl()
                        {
                            ShortUrl = shortUrl,
                            Id = Guid.NewGuid(),
                            CraetedOnUtc= DateTime.UtcNow,
                            LongUrl = longUrl
                        });
                    await _dbontext.SaveChangesAsync();
                    return shortUrl;
                }
            }
            
        }


    }
}
