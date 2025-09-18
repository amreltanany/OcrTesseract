using Microsoft.Win32;
using OCRApp.Common.Types;


namespace OCRApp.Common.Exteneions
{
    internal static  class OpenFileDilogExteneions
    {
        internal static Optional<ImageFilePath> ShowImageDialog(this OpenFileDialog dilog)
        {
            dilog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.tiff";
            dilog.Multiselect = false;
            if (dilog.ShowDialog().Value)
                return ImageFilePath.TryCreate(dilog.FileName);
            return Optional<ImageFilePath>.Empty();
        }
    }
}
