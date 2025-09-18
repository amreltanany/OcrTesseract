using OCRApp.Common.Types;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace OCRApp.Common.Controls
{
    internal class CustomImage : Image
    {
        public event EventHandler? ImageLoaded;
        private void InvokeImageLoaded() => ImageLoaded?.Invoke(this, EventArgs.Empty);

        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register(
                name: "FilePath",
                propertyType:typeof(ImageFilePath),
                ownerType:typeof(CustomImage),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: null, FilePathPropertyChanged));

        public ImageFilePath? FilePath
        {
            
            get => (ImageFilePath?)GetValue(FilePathProperty);
            set => SetValue(FilePathProperty, value);
        }

        private static void FilePathPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            CustomImage? customImage = sender as CustomImage;
            
            if (customImage != null)
            {
                customImage.Source = new BitmapImage(((ImageFilePath)e.NewValue).value);
                customImage.InvokeImageLoaded();
            
            }
        }
    }
}
