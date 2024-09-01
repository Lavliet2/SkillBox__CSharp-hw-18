using Homework_18.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Homework_18.Helpers
{
    public static class EnumHelper
    {
        public static List<EnumValue> AllAnimalTypes { get; } = GetAllAnimalTypes();

        private static List<EnumValue> GetAllAnimalTypes()
        {
            return Enum.GetValues(typeof(AnimalType))
                .Cast<AnimalType>()
                .Select(e => new EnumValue
                {
                    Value = e,
                    Description = GetDescription(e)
                }).ToList();
        }

        private static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }

    public class EnumValue
    {
        public AnimalType Value { get; set; }
        public string Description { get; set; }
    }
}