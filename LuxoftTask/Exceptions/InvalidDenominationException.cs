using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuxoftTask.Exceptions
{
    public class InvalidDenominationException : Exception
    {
        //Exception when a user enters an invalid denomination for curretn country
        public InvalidDenominationException(string message):base(message)
        { }
    }
}
