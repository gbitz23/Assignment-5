using Microsoft.EntityFrameworkCore;

namespace MusicStore.Models
{
    public class MusicContext : DbContext
    {
        public MusicContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Songs> songs { get; set; }
    }
}
