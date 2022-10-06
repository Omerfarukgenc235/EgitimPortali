using EgitimPortali.Models;
using Microsoft.EntityFrameworkCore;

namespace EgitimPortali.Context
{
    public class SqlServerDbContext : DbContext
    {

        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {

        }
        public DbSet<Kategoriler> Kategorilers { get; set; }
        public DbSet<AnaSayfa> AnaSayfas { get; set; }
        public DbSet<DersIcerikleri> DersIcerikleris { get; set; }
        public DbSet<Dersler> Derslers { get; set; }
        public DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public DbSet<Iletisim> Iletisims { get; set; }
        public DbSet<Konular> Konulars { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<KullanicilarinRolleri> KullanicilarinRolleris { get; set; }
        public DbSet<Reklamlar> Reklamlars { get; set; }
        public DbSet<Roller> Rollers { get; set; }
        public DbSet<Sorular> Sorulars { get; set; }
        public DbSet<SorularinCevaplari> SorularinCevaplaris { get; set; }
        public DbSet<Yorumlar> Yorumlars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Users table
            modelBuilder.Entity<Kullanicilar>()
                .HasIndex(b => b.Mail)
                .IsUnique();
            #endregion

            modelBuilder.Entity<KullanicilarinRolleri>()
               .HasKey(pc => new { pc.KullaniciID, pc.RolID });
            modelBuilder.Entity<KullanicilarinRolleri>()
                .HasOne(p => p.Roller)
                .WithMany(pc => pc.KullanicilarinRolleris)
                .HasForeignKey(p => p.RolID);
            modelBuilder.Entity<KullanicilarinRolleri>()
               .HasOne(p => p.Kullanicilar)
               .WithMany(pc => pc.KullanicilarinRolleris)
               .HasForeignKey(c => c.KullaniciID);
        }
    }
}