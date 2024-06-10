using Evbul.Entity;
using Microsoft.EntityFrameworkCore;

namespace Evbul.Data.Concrete.EfCore;

public class EvbulContext : DbContext
{
    public EvbulContext(DbContextOptions<EvbulContext> options) : base(options)
    {
        
    }
    public DbSet<Ev> Evler => Set<Ev>();
    public DbSet<Yorum> Yorumlar => Set<Yorum>();
    public DbSet<Ozellik> Ozellikler => Set<Ozellik>();
    public DbSet<Kullanici> Kullanicilar => Set<Kullanici>();
}
