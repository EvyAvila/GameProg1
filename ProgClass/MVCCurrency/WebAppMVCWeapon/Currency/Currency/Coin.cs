using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyProject
{
    public abstract class Coin : ICoin
    {
        public int Year { get; set; }

        public double MonetaryValue {get; set; }

        public string Name {get; set; }

        public Coin() 
        {
            this.Year = 2017;
        }

        public virtual string About()
        {
            //return String.Empty;
            string CoinAbout = String.Empty;
            CoinAbout += $"{Name} is from {Year}. It is worth {MonetaryValue.ToString("c")}";
            
            return CoinAbout;
        }
    }
}
