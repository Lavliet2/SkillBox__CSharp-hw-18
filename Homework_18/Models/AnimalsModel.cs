using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Data;

namespace Homework_18.Models
{
    public enum AnimalType
    {
        [Description("Млекопитающее")]
        Mammal,
        [Description("Птица")]
        Bird,
        [Description("Земноводное")]
        Amphibian,
        [Description("Неизвестное")]
        Unknown
    }
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
    public class EnumDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class Mammal : IAnimal, INotifyPropertyChanged
    {
        private string _name;
        private string _habitat;
        [Key]
        public int ID { get; set; } 
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(_name));
                }
            }
        }
        public string Habitat
        {
            get { return _habitat; }
            set
            {
                if (_habitat != value)
                {
                    _habitat = value;
                    OnPropertyChanged(nameof(Habitat));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name}, млекопитающее, издает звук.");
        }
    }

    public class Bird : IAnimal, INotifyPropertyChanged
    {
        private string _name;
        private string _habitat;
        [Key]
        public int ID { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(_name));
                }
            }
        }
        public string Habitat
        {
            get { return _habitat; }
            set
            {
                if (_habitat != value)
                {
                    _habitat = value;
                    OnPropertyChanged(nameof(Habitat));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name}, птица, издает звук.");
        }
    }

    public class Amphibian : IAnimal, INotifyPropertyChanged
    {
        private string _name;
        private string _habitat;
        [Key]
        public int ID { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(_name));
                }
            }
        }
        public string Habitat
        {
            get { return _habitat; }
            set
            {
                if (_habitat != value)
                {
                    _habitat = value;
                    OnPropertyChanged(nameof(Habitat));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name}, земноводное, издает звук.");
        }
    }

    public class UnknownAnimal : IAnimal, INotifyPropertyChanged
    {
        private string _name;
        private string _habitat;
        [Key]
        public int ID { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(_name));
                }
            }
        }
        public string Habitat
        {
            get { return _habitat; }
            set
            {
                if (_habitat != value)
                {
                    _habitat = value;
                    OnPropertyChanged(nameof(Habitat));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void MakeSound()
        {
            Console.WriteLine($"{Name}, неизвестное животное, издает звук.");
        }
    }
}
