﻿using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Converters
{
    internal class ImageConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value == null ? new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaApplication1/Assets/UserDefault.jpg"))) : new Bitmap(new MemoryStream((byte[])value));

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
