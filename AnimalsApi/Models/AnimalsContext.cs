using Microsoft.EntityFrameworkCore;

namespace AnimalsApi.Models
{
  public class AnimalsContext : DbContext
  {
    public DbSet<Animal> Animals { get; set; }
    public AnimalsContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Animal>()
        .HasData(
          new Animal 
            { 
              AnimalId = 1, 
              Name = "Spot", 
              Species = "Dog",
              Age = 3,
              About = "lovable little dog found eating a taco in downtown, needs a home" 
            },
          new Animal 
            { 
              AnimalId = 2, 
              Name = "Muffin", 
              Species = "Cat",
              Age = 6,
              About = "this big orange chonk loves to eat and and cuddle needs a home" 
            },
          new Animal 
            { 
              AnimalId = 3, 
              Name = "Mogar the Destroyer", 
              Species = "Inner Dimensional Soul Eater",
              Age = 769736544,
              About = " please help us " 
            }
         
        );
    }
  }
}
