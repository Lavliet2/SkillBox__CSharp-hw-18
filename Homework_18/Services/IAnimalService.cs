using Homework_18.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public interface IAnimalService
{
    Task AddAnimalAsync(AnimalType type, string name, string habitat);
    Task<ObservableCollection<IAnimal>> GetAllAnimalsAsync();
    Task UpdateAnimalAsync(IAnimal animal);
    Task DeleteAnimalAsync(IAnimal animal);
}