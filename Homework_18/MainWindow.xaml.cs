using Homework_18.Interfaces;
using Homework_18.Models;
using Homework_18.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;



namespace Homework_18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAnimalView
    {
        private AnimalPresenter _presenter;
        private string filePath = "Animals";

        public MainWindow()
        {
            InitializeComponent();
            var service = new AnimalService();
            _presenter = new AnimalPresenter(this, service);
        }

        public void DisplayAnimals(ObservableCollection<IAnimal> animals)
        {
            AnimalsDataGrid.ItemsSource = animals;            
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {            
            AddAnimalWindow addAnimalWindow = new AddAnimalWindow();
            addAnimalWindow.ShowDialog();
            _presenter.AddAnimalAsync(addAnimalWindow.Type, addAnimalWindow.Name, addAnimalWindow.Habitat);
        }
        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            IAnimal selectedAnimal = AnimalsDataGrid.SelectedItem as IAnimal;
            if (selectedAnimal != null)
            {
                _presenter.DeleteAnimalAsync(selectedAnimal);
            }
        }

        private void AnimalsDataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedAnimal = e.Row.Item as IAnimal;
                if (editedAnimal != null)
                {
                    _presenter.UpdateAnimalAsync(editedAnimal);
                }
            }
        }

        private async void ExportText_Click(object sender, RoutedEventArgs e)
        {
            string ext = filePath + ".txt";
            var animals = await _presenter.GetAllAnimalsAsync();
            var exportService = new ExportService();
            await exportService.ExportToTextAsync(animals, ext);
        }

        private async void ExportPDF_Click(object sender, RoutedEventArgs e)
        {
            string ext = filePath + ".pdf";
            var animals = await _presenter.GetAllAnimalsAsync();
            var exportService = new ExportService();
            await exportService.ExportToPdfAsync(animals, ext);
        }

        private async void ExportExcel_Click(object sender, RoutedEventArgs e)
        {
            string ext = filePath + ".xlsx";
            var animals = await _presenter. GetAllAnimalsAsync();
            var exportService = new ExportService();
            await exportService.ExportToExcelAsync(animals, ext);
        }
    }
}
