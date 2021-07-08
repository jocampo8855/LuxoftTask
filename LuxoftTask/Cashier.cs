using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftTask
{
    public class Cashier
    {
        //validate amount of money is equal or bigger than price
        public bool ValidatePayment(double price, double amount)
        {
            return amount >= price;
        }

        //Main Task to calculate optimum change
        public List<double> CalculateChange(double price, List<double> amount)
        {
            //List to recolect bills and coins to complete the change
            List<double> amountChange = new List<double>();

            //validate if they pay exactly
            if (amount.Sum() == price)
                return amountChange;
            else
            {
                var change = amount.Sum() - price;

                //Revert Denomination positions 
                MachineConfig.countryDenomination.Reverse();
                foreach (double den in MachineConfig.countryDenomination)
                {
                    if (den > change)
                        continue;
                    else
                    {
                        while((den + amountChange.Sum() <= change))
                        {
                            amountChange.Add(den);
                        }
                    }

                    if (amountChange.Sum() == change)
                        break;
                }
            }

            return amountChange;
        }
    }
}
