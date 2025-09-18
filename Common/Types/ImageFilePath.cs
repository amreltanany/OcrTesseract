//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.IO;
using System.Runtime.InteropServices;

namespace OCRApp.Common.Types
{
    internal class ImageFilePath
    {
        private readonly FileInfo fileInfo;

        public Uri value => new Uri(fileInfo.FullName);

        public ImageFilePath(FileInfo fileInfo) => this.fileInfo = fileInfo;

        internal static Optional<ImageFilePath> TryCreate(string value)
        {
            try 
            {
                FileInfo fileInfo = new FileInfo(value); 
                if (fileInfo.Exists)
                    return Optional<ImageFilePath>.Create(new ImageFilePath(fileInfo));
                return Optional<ImageFilePath>.Empty();   
            }
            catch
            {
                return Optional<ImageFilePath>.Empty();
            }
            //{
            //    return new OptionalAttribute<ImageFilePath>();
            //}
            //var extension = fileInfo.Extension.ToLowerInvariant();
            //if (extension != ".png" && extension != ".jpg" && extension != ".jpeg" && extension != ".bmp" && extension != ".tiff")
            //{
            //    return new OptionalAttribute<ImageFilePath>();
            //}
            //return new OptionalAttribute<ImageFilePath>(new ImageFilePath(fileInfo));
        }

    }
}
