using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace PRODUX.View.Convertidores
{
    public class ImagenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ImageSource retSource = null;
            if (value != null)
            {
                if (((string)value).Contains("http"))
                {
                    retSource = ImageSource.FromUri(new Uri((string)value));
                }
                else
                {
                    byte[] imageAsBytes = System.Convert.FromBase64String((string)value);
                    retSource = ImageSource.FromStream(() => new MemoryStream(imageAsBytes));
                }
            }
            return retSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
