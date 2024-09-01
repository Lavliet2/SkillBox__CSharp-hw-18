using Homework_18.Models;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Homework_18.Data
{
    public class AnimalContext : DbContext
    {
        public DbSet<Mammal> Mammals { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public DbSet<Amphibian> Amphibians { get; set; }
        public DbSet<UnknownAnimal> UnknownAnimals { get; set; }
    }
}
