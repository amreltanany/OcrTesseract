
using OCRApp.Common.Types;
using System.Windows;

namespace OCRApp.Common.Controls
{
    public partial class OcrControl
    {
        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register(
                name: "FilePath",
                propertyType: typeof(ImageFilePath),
                ownerType: typeof(OcrControl),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: null, FilePathPropertyChanged));
        internal ImageFilePath filePath
        {
            get => (ImageFilePath)GetValue(FilePathProperty);
            set => SetValue(FilePathProperty, value);
        }
        private static void FilePathPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            OcrControl? Control = sender as OcrControl;
            if (Control != null)
            {
                Control.maybeImageFilePath = Optional<ImageFilePath>.MaybeCreate(e.NewValue as ImageFilePath);
               
            }
        }
        public static readonly DependencyProperty StatusProperty =
            DependencyProperty.Register(
                name: "Status",
                propertyType: typeof(string),
                ownerType: typeof(OcrControl),
                typeMetadata: new FrameworkPropertyMetadata(defaultValue: string.Empty));
        internal string Status
        {
            
            get => (string)GetValue(StatusProperty);
            set => SetValue(StatusProperty, value);
        }
    }
}
