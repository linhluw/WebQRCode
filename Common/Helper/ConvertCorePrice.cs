using System;

namespace MyWeb.Common.Helper
{
    public class ConvertCorePrice
    {
        public static string ConvertPriceTy(string price)
        {
            var str = string.Empty;
            if (price.Length > 3)
            {
                int length = price.Length;
                while (length > 3)
                {
                    price = price.Insert(length - 3, " tỷ ");
                    length = length - 3;
                }

                str = (price + " triệu").Replace("000 triệu", string.Empty);

                return str;
            }
            else
            {
                return price + " triệu";
            }
        }

        public static string ConvertPrice(string price)
        {
            if (price == "0")
            {
                price = "Liên hệ";
                return price;
            }
            else
            {
                if (price.Length > 3)
                {
                    int length = price.Length;
                    while (length > 3)
                    {
                        price = price.Insert(length - 3, ".");
                        length = length - 3;
                    }
                    return price + " VND";
                }
                else
                {
                    return price + " VND";
                }
            }

        }

        public static string ConvertMoney(string price)
        {
            if (price.Length > 3)
            {
                int length = price.Length;
                while (length > 3)
                {
                    price = price.Insert(length - 3, ".");
                    length = length - 3;
                }
                return price;
            }
            else
            {
                return price;
            }
        }

        public static string ConvertMoneyVND(string price)
        {
            if (float.Parse(price) >= 0)
            {
                if (price.Length > 3)
                {
                    int length = price.Length;
                    while (length > 3)
                    {
                        price = price.Insert(length - 3, ".");
                        length = length - 3;
                    }
                    return price + " VND";
                }
                else
                {
                    return price + " VND";
                }
            }
            else
            {
                string priceII = price.Replace("-", "");
                if (priceII.Length > 3)
                {
                    int length = priceII.Length;
                    while (length > 3)
                    {
                        priceII = priceII.Insert(length - 3, ".");
                        length = length - 3;
                    }
                    return "-" + priceII + " VND";
                }
                else
                {
                    return "-" + priceII + " VND";
                }
            }
        }

        public static string lamtronphay(string so)
        {
            int vitri = 0;
            vitri = so.IndexOf(".");
            if (vitri > 0)
            {
                int vitribatdau = vitri + 1;
                string a = so.Substring(vitribatdau, 1);
                if (Int32.Parse(a) > 4)
                {
                    so = (decimal.Parse(so.Substring(0, vitri)) + 1).ToString();
                }
                else
                {
                    so = decimal.Parse(so.Substring(0, vitri)).ToString();
                }
            }
            return so;
        }

        public static string hienthiMonneyII(string so)
        {
            int vitri = 0;
            vitri = so.IndexOf(".");
            if (vitri > 0)
            {
                int lengt = so.Length;
                int vitribatdau = vitri + 1;
                string sophay = so.Substring(vitribatdau, lengt - vitribatdau);
                so = ConvertMoney(so.Substring(0, vitri)) + "," + sophay;
            }
            else
            {
                so = ConvertMoney(so);
            }
            return so;
        }

        public static string lamtron5k(string so)
        {
            int a = so.Length;
            if (a >= 4)
            {
                string b = so.Substring(a - 4, 4);
                if (decimal.Parse(b) > 5000)
                {
                    so = (decimal.Parse(so) + 10000 - decimal.Parse(b)).ToString();
                }
                else if (decimal.Parse(b) < 5000)
                {
                    //so = (decimal.Parse(so) - decimal.Parse(b)).ToString();
                    if (decimal.Parse(b) == 0)
                    {
                        so = (decimal.Parse(so) - decimal.Parse(b)).ToString();
                    }
                    else
                    {
                        so = (decimal.Parse(so) - decimal.Parse(b) + 5000).ToString();
                    }
                }
            }
            return so;
        }
    }
}