using Homework_18.Models;
using System.Collections.ObjectModel;

namespace Homework_18.Interfaces
{
    public interface IAnimalView
    {
        void DisplayAnimals(ObservableCollection<IAnimal> animals);
    }
}
