using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using WindowFM.Shared.ViewModels;

namespace WindowFM.WPF.UI
{
    internal class FileEntityToImgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dravingImage = new DrawingImage();
            if (value is DirectoryViewModel)
            {
                var resource = Application.Current.TryFindResource("FolderIcon");
                if (resource is ImageSource drawingImage)
                    return drawingImage;
            }
            else if (value is FileViewModel)
            {
                var resource = Application.Current.TryFindResource("FileIcon");
                if (resource is ImageSource drawingImage)
                    return drawingImage;
            }

            return dravingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
