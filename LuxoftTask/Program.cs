using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //property used to catch bills and coins entered by customer
            List<double> _amount = new List<double>();

            try
            {
                //variable used to set currency
                Console.WriteLine("Please enter your country code");
                var country = Console.ReadLine();
                MachineConfig.Setup(country);

                Console.WriteLine("Please enter price of the item:");
                double price = Double.Parse(Console.ReadLine());


                //ask for money until complete payment
                Cashier cashier = new Cashier();
                do
                {
                    Console.WriteLine("Please complete payment: ");
                    _amount.Add(Double.Parse(Console.ReadLine()));
                }
                while (cashier.ValidatePayment(price, _amount.Sum()) == false);

                //call cashier method to calculate change
                var change = cashier.CalculateChange(price, _amount);

                Console.WriteLine("Your Change:");
                foreach (var den in change.Distinct())
                {
                    Console.WriteLine($"{change.FindAll(x => x.Equals(den)).Count} x {den}");
                }

                Console.ReadLine();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
