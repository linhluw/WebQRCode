using MyWeb.Common.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using ZXing;

namespace WebQRCode
{
    /// <summary>
    /// Summary description for FileUpload
    /// </summary>
    public class FileUpload : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count > 0)
            {
                var date = DateTime.Now;
                var year = date.Year;
                var month = date.Month;
                var day = date.Day;
                string path = HttpContext.Current.Server.MapPath(string.Format("/uploads/{0}/{1}/{2}", year, month, day));
                if (!Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
                {
                    Directory.CreateDirectory(path);
                }
                HttpFileCollection files = context.Request.Files;
                int count = 0;
                for (int i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];
                    if (file.FileName.EndsWith(".jpg") || file.FileName.EndsWith(".jpge")
                         || file.FileName.EndsWith(".png"))
                    {

                        var name = bitmapImage(file.InputStream, file.FileName, path);
                        if (!string.IsNullOrEmpty(name))
                        {
                            count++;

                            GenFileClass.Create(path + "\\", string.Format("{0}. {1}", count, name));

                        }
                    }
                }

                context.Response.ContentType = "text/plain";
                context.Response.Write(string.Format("Đã upload thành công {0} ảnh", count));
            }
        }

        public string bitmapImage(System.IO.Stream stream, string ten, string path)
        {
            string str = string.Empty;
            Bitmap img = new Bitmap(stream);
            IBarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(img);
            if (!string.IsNullOrEmpty(result.Text))
            {
                string strExtension = Path.GetExtension(ten);
                string pathimg = path + "\\" + result.Text + strExtension;
                HelpImages.ResizeImage1Chieu(img, 1000, 1000, 100, pathimg);
                img.Dispose();
                str = result.Text;
            }
            return str;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}