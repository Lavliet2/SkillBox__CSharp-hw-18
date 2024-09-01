using Homework_18.Interfaces;
using Homework_18.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public class AnimalPresenter
{
    private readonly IAnimalView _view;
    private readonly IAnimalService _service;

    public AnimalPresenter(IAnimalView view, IAnimalService service)
    {
        _view = view;
        _service = service;
        LoadAnimalsAsync();
    }

    public async void AddAnimalAsync(AnimalType type, string name, string habitat)
    {
        await _service.AddAnimalAsync(type, name, habitat);
        await LoadAnimalsAsync();
    }

    public async Task LoadAnimalsAsync()
    {
        var animals = await _service.GetAllAnimalsAsync();
        _view.DisplayAnimals(animals);
    }

    public async void UpdateAnimalAsync(IAnimal animal)
    {
        await _service.UpdateAnimalAsync(animal);
        await LoadAnimalsAsync();
    }

    public async void DeleteAnimalAsync(IAnimal animal)
    {
        await _service.DeleteAnimalAsync(animal);
        await LoadAnimalsAsync();
    }

    public async Task<ObservableCollection<IAnimal>> GetAllAnimalsAsync()
    {
        return await _service.GetAllAnimalsAsync();        
    }
}