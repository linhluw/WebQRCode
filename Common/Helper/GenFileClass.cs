﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace MyWeb.Common.Helper
{
    public class GenFileClass
    {
        public static void Create(string path, string item)
        {
            // Creating a file
            var fileName = string.Format("LogEvent_{0}.txt", DateTime.Now.ToString("ddMMyyyy")).ToUpper();

            string myfile = string.Format(path + "{0}", fileName);

            // Checking the above file
            if (!File.Exists(myfile))
            {
                string directoryPath = Path.GetDirectoryName(myfile);

                // Nếu chưa tồn tại thư mục thì tạo thư mục.
                if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

                // Creating the same file if it doesn't exist
                using (StreamWriter sw = File.CreateText(myfile))
                {
                    sw.WriteLine(item);
                }
            }

            else
            {
                // Appending the given texts
                using (StreamWriter sw = File.AppendText(myfile))
                {
                    sw.WriteLine(item);
                }
            }
        }

        public static List<ReadLogFileRespone> Read(DateTime dateTime)
        {
            var respone = new List<ReadLogFileRespone>();
            try
            {
                // Creating a file
                var fileName = string.Format("LogEvent_{0}.txt", dateTime.ToString("ddMMyyyy")).ToUpper();

                string myfile = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"LogDataEvent" + Path.DirectorySeparatorChar + "{0}", fileName);
                // Checking the above file
                if (File.Exists(myfile))
                {
                    // Opening the file for reading
                    using (StreamReader sr = File.OpenText(myfile))
                    {
                        string s = string.Empty;
                        while ((s = sr.ReadLine()) != null)
                        {
                            var item = s.Split('|');
                            if (item.Length > 0)
                            {
                                if (!string.IsNullOrEmpty(item[0].Trim()))
                                {
                                    try
                                    {
                                        respone.Add(new ReadLogFileRespone
                                        {
                                            CreatedDate = DateTime.ParseExact(item[0].Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture),
                                            Detail = item[1].Trim()
                                        });
                                    }
                                    catch { }

                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return respone;
        }

        public static List<string> ReadThuongHieu()
        {
            var respone = new List<string>();
            try
            {
                // Creating a file
                var fileName = "ThuongHieu.txt";

                string myfile = AppDomain.CurrentDomain.BaseDirectory + string.Format(@"uploads" + Path.DirectorySeparatorChar + "{0}", fileName);
                // Checking the above file
                if (File.Exists(myfile))
                {
                    // Opening the file for reading
                    using (StreamReader sr = File.OpenText(myfile))
                    {
                        string s = string.Empty;
                        while ((s = sr.ReadLine()) != null)
                        {

                            if (!string.IsNullOrEmpty(s.Trim()))
                            {
                                try
                                {
                                    respone.Add(s.Trim());
                                }
                                catch { }

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            return respone;
        }
    }

    public class ReadLogFileRespone
    {
        public DateTime CreatedDate { get; set; }

        public string Detail { get; set; } = string.Empty;
    }
}