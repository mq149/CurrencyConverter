using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.Models
{
    public class Converter
    {
        public float amount;
        public float exchangeRate;
        public float result;
        public string resultString;

        public Converter(float amount, float exchangeRate)
        {
            this.amount = amount;
            this.exchangeRate = exchangeRate;
        }

        public void convert()
        {
            result = amount * exchangeRate;
            resultString = "Result: " + result.ToString("0,000.0000") + " VND";
        }
    }
}
