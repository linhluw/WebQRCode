using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing;
using static System.Net.WebRequestMethods;

namespace WebQRCode
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            var year = date.Year;
            var month = date.Month;
            var day = date.Day;
            string path = HttpContext.Current.Server.MapPath(string.Format("/uploads/{0}/{1}/{2}", year, month, day));
            if (Directory.Exists(path))   // CHECK IF THE FOLDER EXISTS. IF NOT, CREATE A NEW FOLDER.
            {
                Directory.Delete(path, true);
            }
            
        }
    }
}