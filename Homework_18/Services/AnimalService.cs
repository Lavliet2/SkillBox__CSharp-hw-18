using Homework_18.Data;
using Homework_18.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.ObjectModel;
using DocumentFormat.OpenXml.Wordprocessing;
using Homework_18.Factories;

namespace Homework_18.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly AnimalContext _context;

        public AnimalService()
        {
            _context = new AnimalContext();
        }

        public async Task AddAnimalAsync(AnimalType type, string name, string habitat)
        {
            var factory = new AnimalFactory();
            var animal = factory.CreateAnimal(type, name, habitat);

            _context.Set(animal.GetType()).Add(animal);
            await _context.SaveChangesAsync();
        }

        public async Task<ObservableCollection<IAnimal>> GetAllAnimalsAsync()
        {
            using (var context = new AnimalContext())
            {
                var mammals = await context.Mammals.ToListAsync();
                var birds = await context.Birds.ToListAsync();
                var amphibians = await context.Amphibians.ToListAsync();
                var unknowns = await context.UnknownAnimals.ToListAsync();

                var allAnimals = new ObservableCollection<IAnimal>(mammals.Cast<IAnimal>().Concat(birds).Concat(amphibians).Concat(unknowns));
                return allAnimals;
            }
        }

        public async Task UpdateAnimalAsync(IAnimal animal)
        {
            var existingAnimal = await _context.Set(animal.GetType()).FindAsync(animal.ID);
            if (existingAnimal != null)
            {
                _context.Entry(existingAnimal).CurrentValues.SetValues(animal);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAnimalAsync(IAnimal animal)
        {
            switch (animal)
            {
                case Mammal mammal:
                    _context.Entry(mammal).State = EntityState.Deleted;
                    break;
                case Bird bird:
                    _context.Entry(bird).State = EntityState.Deleted;
                    break;
                case Amphibian amphibian:
                    _context.Entry(amphibian).State = EntityState.Deleted;
                    break;
                case UnknownAnimal unknown:
                    _context.Entry(unknown).State = EntityState.Deleted;
                    break;
            }

            await _context.SaveChangesAsync();
        }
    }
}