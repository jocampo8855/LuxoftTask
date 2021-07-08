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
        public static List<double> countryDenomination = new List<double>();


        public static void Setup(string countryCode)
        {
            var currencyList = ConfigurationSettings.AppSettings[countryCode];
            countryDenomination = currencyList.Split(',').Select(Double.Parse).ToList();
        }
    }
}
