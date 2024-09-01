using Homework_18.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Homework_18.Services
{
    public interface IExportService
    {
        Task ExportToExcelAsync(ObservableCollection<IAnimal> animals, string path);
        Task ExportToTextAsync(ObservableCollection<IAnimal> animals, string path);
        Task ExportToPdfAsync(ObservableCollection<IAnimal> animals, string path);
    }
}
