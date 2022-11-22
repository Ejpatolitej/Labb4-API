using Microsoft.EntityFrameworkCore;

namespace Labb4_API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        public DbSet<Person> people { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Website> Websites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 1, FirstName = "Jack", LastName = "Niklasson", Phone = "0722211144" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 2, FirstName = "Emma", LastName = "Whiteside", Phone = "0700021212" });
            modelBuilder.Entity<Person>().HasData(new Person { PersonID = 3, FirstName = "Timothy", LastName = "Borgäng", Phone = "0731312224" });

            modelBuilder.Entity<Interest>().HasData(new Interest { InterestID = 1, InterestTitle = "Horses", InterestDescript = "I Love Horses", PersonID = 1 });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestID = 2, InterestTitle = "Computers", InterestDescript = "Computers are awesome", PersonID = 2 });
            modelBuilder.Entity<Interest>().HasData(new Interest { InterestID = 3, InterestTitle = "Minecraft", InterestDescript = "I Mine all day...", PersonID = 3 });

            modelBuilder.Entity<Website>().HasData(new Website { WebsiteID = 1, PersonID = 1, WebpageLink = "www.Horse.com"});
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteID = 2, PersonID = 2, WebpageLink = "www.Minecraft.net/mine/all/day"});
            modelBuilder.Entity<Website>().HasData(new Website { WebsiteID = 3, PersonID = 1, WebpageLink = "www.MoreHorses.pl"});

        }
    }
}
