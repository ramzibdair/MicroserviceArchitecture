using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;
using WebApplication1.Services;

namespace WebApplication1
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions): base(dbContextOptions) { }
        
        public DbSet<ShortenUrl> ShortenUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShortenUrl>(builder =>
            {
                builder.Property(s => s.ShortUrl).HasMaxLength(IShortenUrlServices.NumberOfCharactersInShortUrl);
                builder.HasIndex(s => s.ShortUrl).IsUnique();
                builder.HasKey(s => s.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
