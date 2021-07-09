using LuxoftTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftTask
{
    public class Cashier:ICashier
    {
        List<double> _countryDenomination;
        public Cashier(List<double> countryDenomination)
        {
            _countryDenomination = countryDenomination;
        }
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
            if (amount.Sum() != price)
            {
                var change = amount.Sum() - price;

                //Revert Denomination positions 
                _countryDenomination.Reverse();
                foreach (double denomination in _countryDenomination)
                {
                    if (denomination > change)
                        continue;
                    else
                    {
                        while((denomination + amountChange.Sum() <= change))
                        {
                            amountChange.Add(denomination);
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
