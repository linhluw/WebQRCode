using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MyWeb.Common.Helper
{
    public class StringClass
    {
        public static string NameToSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string NameToTag(string strName)
        {
            string strReturn = "";
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            strReturn = Regex.Replace(strName, "[^\\w\\s]", string.Empty).Replace(" ", "-").ToLower();
            string strFormD = strReturn.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, string.Empty).Replace("đ", "d");
        }

        public static string NameIsInvest(bool item)
        {
            return item ? "Căn đầu tư" : "Không";
        }

        public static string GetLinkImages(string link, int size)
        {
            string str = string.Empty;
            str = "https://img.nhalinhdam.com/" + "Image.ashx?src=" + link.Replace("https://img.nhalinhdam.com", string.Empty) + "&width=" + size + "";
            return str;
        }

        public static string Viewurl(string building, double price, int bedroomsnumber, int doordirection, int balconydirection, int groupnewsid, int fromfloornumber, int tofloornumber, int pageindex)
        {
            return "/view?building=" + building + "&price=" + price + "&bedroomsnumber=" + bedroomsnumber + "&doordirection=" + doordirection + "&balconydirection=" + balconydirection + "&groupnewsid=" + groupnewsid + "&fromfloornumber=" + fromfloornumber + "&tofloornumber=" + tofloornumber + "&pageindex=" + pageindex + "";
        }

        public static string EncodeFloorPenKiot(int number)
        {
            string str = "0";
            if (number == -1)
            {
                str = "Kiot";
            }
            else if (number == 1000)
            {
                str = "Pen";
            }
            else
            {
                str = number.ToString();
            }
            return str;
        }

        public static int DecodeFloorPenKiot(string str)
        {
            int value = 0;
            if (str.ToLower() == "kiot")
            {
                value = -1;
            }
            else if (str.ToLower() == "pen")
            {
                value = 1000;
            }
            else
            {
                value = int.Parse(str);
            }
            return value;
        }
    }
}