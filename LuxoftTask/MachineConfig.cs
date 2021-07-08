using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace LuxoftTask
{
    public static class MachineConfig
    {
        readonly static Logger logger = new Logger();
        public static List<double> countryDenomination = new List<double>();


        public static void Setup(string countryCode)
        {
            try
            {
                var currencyList = ConfigurationSettings.AppSettings[countryCode];
                countryDenomination = currencyList.Split(',').Select(Double.Parse).ToList();
            }
            catch(Exception ex)
            {
                logger.Log(ex.Message);
            }
        }
    }
}
