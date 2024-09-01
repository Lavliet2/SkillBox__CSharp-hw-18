namespace Homework_18.Models
{
    public interface IAnimal
    {
        int ID { get; set; }
        string Name { get; set; }
        string Habitat { get; set; }
        void MakeSound();
    }
}
