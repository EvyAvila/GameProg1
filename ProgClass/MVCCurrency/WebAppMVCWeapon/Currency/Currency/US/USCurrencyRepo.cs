using CurrencyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Currency.US
{
    public class USCurrencyRepo : CurrencyRepo
    {        

        public USCurrencyRepo()
        {
            
        }

        public USCurrencyRepo(double num) //List<ICurrency> coins
        {
            MakeChange(num);
        }

        // HOW DOES THIS WORK???? WHY IS IT FINE??
        /*
        public static USCurrencyRepo CreateChange(double Amount)
        {

            return new USCurrencyRepo(Amount);
        }*/


        //Works fine, but if the test doesn't have a cast it doesn't like it
        
        public static ICurrencyRepo CreateChange(double Amount)
        {
           return new USCurrencyRepo(Amount);
        }


    }
}
