using ConversorAPI.Entites;
using Microsoft.EntityFrameworkCore;

namespace ConversorAPI.Data
{
    public class ConversorDbContext : DbContext
    {
        public ConversorDbContext(DbContextOptions<ConversorDbContext> options) : base(options)
        {
            //
        }

        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<CurrencyConversion> CurrencyConversions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Subscription free = new Subscription()
            {
                Id = 1,
                Name = "Free",
                AmountOfConversion = 10,
                Price = 0
            };

            Subscription premium = new Subscription()
            {
                Id = 2,
                Name = "Premium",
                AmountOfConversion = 100,
                Price = 10
            };

            Subscription full = new Subscription()
            {
                Id = 3,
                Name = "Full",
                AmountOfConversion = -1,
                Price = 25
            };

            User admin = new User()
            {
                Id = 1,
                Email = "joaquinvirgili1@gmail.com",
                Password = "password",
                Name = "admin",
                LastName = "admin",
                SubscriptionId = full.Id,
                Role = Models.Enum.RoleEnum.Admin
            };

            User user = new User()
            {
                Id = 2,
                Email = "userexample@gmail.com",
                Password = "password",
                Name = "user",
                LastName = "user",
                SubscriptionId = free.Id,
            };

            Currency usd = new Currency() 
            {
                Id = 1,
                Name = "Dolar Estadounidense",
                Symbol = "U$D",
                Value = 1
            };

            Currency euro = new Currency()
            {
                Id = 2,
                Name = "Euro",
                Symbol = "€",
                Value = 1.09
            };

            Currency peso = new Currency()
            {
                Id = 3,
                Name = "Peso Argentino",
                Symbol = "$",
                Value = 0.0002
            };

            CurrencyConversion usdAPeso = new CurrencyConversion()
            {
                Id = 1,
                ToCurrencyId = usd.Id,
                FromCurrencyId = peso.Id,
                Amount = 10,
                UserId = 2
            };

            modelBuilder.Entity<Subscription>()
                .HasData(free, premium, full);

            modelBuilder.Entity<User>()
                .HasData(admin, user);

            modelBuilder.Entity<Currency>()
                .HasData(usd, euro, peso);

            modelBuilder.Entity<CurrencyConversion>()
                .HasData(usdAPeso);
            
            modelBuilder.Entity<User>()
                .HasOne<Subscription>(s => s.Subscription)
                .WithMany(u => u.Users);

            modelBuilder.Entity<User>()
                .HasMany(c => c.CurrencyConversion)
                .WithOne(u => u.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CurrencyConversion>()
                .HasOne(c => c.FromCurrency)
                .WithMany()
                .HasForeignKey(c => c.FromCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CurrencyConversion>()
                .HasOne(c => c.ToCurrency)
                .WithMany()
                .HasForeignKey(c => c.ToCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
