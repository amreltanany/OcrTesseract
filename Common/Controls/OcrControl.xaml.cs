
using OCRApp.Common.Types;
using System.Windows.Controls;
using TesseractOCR;
using TesseractOCR.Enums;

namespace OCRApp.Common.Controls
{
    /// <summary>
    /// Interaction logic for OcrControl.xaml
    /// </summary>
    public partial class OcrControl : UserControl
    {
       
        private readonly Engine engine = new Engine(@"./tessdata", TesseractOCR.Enums.Language.English, EngineMode.Default);
        private Optional<ImageFilePath> maybeImageFilePath = Optional<ImageFilePath>.Empty();
        public OcrControl() => InitializeComponent();
        internal void OcrImage() => maybeImageFilePath.Do(ocr);
        private void ocr(ImageFilePath imageFilePath)
        {
            try
            {
                using var img = TesseractOCR.Pix.Image.LoadFromFile(imageFilePath.value.AbsolutePath);
                using var page = engine.Process(img);
                ocrText.Text = page.Text;
                Status = $"Status: {page.MeanConfidence * 100}% confidence";
            }
            catch (Exception ex)
            {
                ocrText.Text = string.Empty;
                Status = $"Status: Failed to OCR Image. Error: {ex.Message}";
            }
        }
    }
}
