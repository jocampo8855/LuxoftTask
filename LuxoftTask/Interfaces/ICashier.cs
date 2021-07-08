using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftTask.Interfaces
{
    public interface ICashier
    {
        bool ValidatePayment(double price, double amount);

        List<double> CalculateChange(double price, List<double> amount);
    }
}
