using Microsoft.Win32;
using OCRApp.Common.Exteneions;
using OCRApp.Common.Types;
using System.Windows;

namespace OCRApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void OpenImage(object sender, RoutedEventArgs e) =>
            new OpenFileDialog()
            .ShowImageDialog()
            .Do(StartProcess);

        private void StartProcess(ImageFilePath imageFilePath) =>Image.FilePath = Ocr.filePath = imageFilePath;

        private void ImageLoaded(object sender, EventArgs e) => Ocr.OcrImage();
        private void Image_ImageLoaded(object sender, EventArgs e)
        {

        }
    }
}