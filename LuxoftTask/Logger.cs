using LuxoftTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LuxoftTask
{
    public class Logger : ILogger
    {
        private string CurrentDirectory { get; set; }
        private string FileName { get; set; }

        private string FilePath { get; set; }

        public Logger()
        {
            //initialize properties to save the log file
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = $"{this.CurrentDirectory}/{this.FileName}";
        }
        public void Log(string message)
        {
            try
            {
                
                using(StreamWriter w = File.AppendText(this.FilePath))
                {
                    w.Write("\r\nLog Entry");
                    w.WriteLine($"{DateTime.Now.ToLongDateString()} - {DateTime.Now.ToLongTimeString()}");
                    w.WriteLine($":{message}");
                    w.WriteLine("============================================================");
                }

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
