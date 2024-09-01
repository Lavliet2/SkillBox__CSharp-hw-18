using Homework_18.Models;
using System;

namespace Homework_18.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(AnimalType type, string name, string habitat)
        {
            switch (type)
            {
                case AnimalType.Mammal:
                    return new Mammal { Name = name, Habitat = habitat };
                case AnimalType.Bird:
                    return new Bird { Name = name, Habitat = habitat };
                case AnimalType.Amphibian:
                    return new Amphibian { Name = name, Habitat = habitat };
                case AnimalType.Unknown:
                default:
                    return new UnknownAnimal { Name = name, Habitat = habitat };
                    //throw new ArgumentException("Invalid animal type");
            }
        }
    }
}