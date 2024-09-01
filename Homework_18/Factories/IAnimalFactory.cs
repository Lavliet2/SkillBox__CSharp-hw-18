using Homework_18.Models;

namespace Homework_18.Factories
{
    public interface IAnimalFactory
    {
        IAnimal CreateAnimal(AnimalType type, string name, string habitat);
    }
}