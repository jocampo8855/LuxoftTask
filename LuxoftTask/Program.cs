using LuxoftTask.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add Logger
            Logger logger = new Logger();
            //get denomination list from settings
            List<double> countryDenomination = new List<double>();
            //property used to catch bills and coins entered by customer
            List<double> _amount = new List<double>();

            try
            {
                //variable used to set currency
                CultureInfo culture = new CultureInfo(ConfigurationSettings.AppSettings["locale"]);
                var region = new RegionInfo(culture.LCID);
                var currencyList = ConfigurationSettings.AppSettings[region.TwoLetterISORegionName];
                countryDenomination = currencyList.Split(',').Select(Double.Parse).ToList();

                Console.WriteLine("Please enter price of the item:");
                var readValue = Console.ReadLine();
                double price;
                if (Double.TryParse( readValue, out price))
                {
                    //ask for money until complete payment
                    Cashier cashier = new Cashier(countryDenomination);
                    do
                    {
                        Console.WriteLine("Please complete payment: ");
                        var readPayment= Console.ReadLine();
                        double cash;
                        if(Double.TryParse(readPayment, out cash))
                        {
                            //validate if denomination entered is valid or setn custom exception
                            if (!countryDenomination.Contains(cash))
                                throw (new InvalidDenominationException("Invalid denomination for country"));
                            else
                                _amount.Add(cash);
                        }
                        else
                        {
                            Console.WriteLine($"Unable to parse {readPayment} while payment");
                            break;
                        }
                    }
                    while (cashier.ValidatePayment(price, _amount.Sum()) == false);

                    //call cashier method to calculate change
                    var change = cashier.CalculateChange(price, _amount);

                    Console.WriteLine("Your Change:");
                    foreach (var den in change.Distinct())
                    {
                        Console.WriteLine($"{change.FindAll(x => x.Equals(den)).Count} x {den}");
                    }
                }
                else
                    Console.WriteLine($"Unable to Parse {readValue}");

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                logger.Log(ex.Message);
            }
        }
    }
}
