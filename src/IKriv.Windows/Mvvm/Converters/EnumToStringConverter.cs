﻿using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace IKriv.Windows.Mvvm.Converters
{
    public class EnumToStringConverter : MarkupExtension, IValueConverter
    {
        public string NoneValue { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return NoneValue;

            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return null;

            if (value.ToString() == NoneValue) return null;

            Type type = parameter as Type;

            if (type == null) return DependencyProperty.UnsetValue;

            return Enum.Parse(type, value.ToString());
        }
    }
}