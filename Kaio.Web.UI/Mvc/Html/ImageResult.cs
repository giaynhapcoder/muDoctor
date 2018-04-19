using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Kaio.Web.UI
{
    public class ImageResult : ActionResult
    {

        public ImageResult(string imagePath, string etag)
        {

            if (imagePath == null)

                throw new ArgumentNullException("Image is null or empty");

            ImagePath = imagePath;

            ETag = etag;

        }


        public string ImagePath { get; private set; }

        public string ETag { get; private set; }


        public override void ExecuteResult(ControllerContext context)
        {

            if (context == null)

                throw new ArgumentNullException("context");

            HttpResponseBase _response = context.HttpContext.Response;

            var _data = File.ReadAllBytes(ImagePath);

            _response.Clear();
            
            _response.ContentType = ImageType(Path.GetExtension(ImagePath));
            _response.Cache.SetMaxAge(TimeSpan.FromDays(365));
            _response.Cache.SetETag(ETag);
            _response.Cache.SetCacheability(HttpCacheability.Public);
            _response.Cache.SetExpires(DateTime.Now.AddYears(1));
            _response.OutputStream.Write(_data, 0, _data.Length);
            _response.Flush();
            _response.End();

        }

        private string ImageType(string extension)
        {
            switch (extension.ToUpper())
            {

                case ".GIF":
                    return "image/gif";
                case ".BMP":
                    return "image/bmp";
                case ".PNG":
                    return "image/png";
                case ".TIFF":
                case ".TIF":
                    return "image/tif";
                default:
                    return "image/jpeg";

            }
        }

    }
}
