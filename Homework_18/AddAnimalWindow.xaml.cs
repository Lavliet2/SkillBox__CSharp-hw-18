using Homework_18.Models;
using Homework_18.Factories;
using System;
using System.Linq;
using System.Windows;

namespace Homework_18
{
    /// <summary>
    /// Логика взаимодействия для AddAnimalWindow.xaml
    /// </summary>
    public partial class AddAnimalWindow : Window
    {
        public AnimalType Type { get; private set; }
        public string Habitat { get; private set; }
        public string Name { get; private set; }

        public AddAnimalWindow()
        {
            InitializeComponent();
            habitatComboBox.ItemsSource = Enum.GetValues(typeof(AnimalType))
                .Cast<AnimalType>()
                .Select(e => e.GetDescription());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedType = habitatComboBox.SelectedItem.ToString();
            this.Type = Enum.GetValues(typeof(AnimalType))
                          .Cast<AnimalType>()
                          .FirstOrDefault(t => t.GetDescription() == selectedType);
            this.Name = Type.GetDescription();
            this.Habitat = habitatTextBox.Text;

            if (String.IsNullOrEmpty(Habitat)) return;
            this.DialogResult = true;
            this.Close();

        }
    }
}
