using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CurrencyProject;

namespace Currency.US
{
    public enum USCoinMintMark { P, D, S, W }
    public abstract class USCoin : Coin
    {
        public USCoinMintMark MintMark { get; set; }

        public USCoin()
        {
            //MonetaryValue = 0.01;
            
        }

        public USCoin(USCoinMintMark mintMark)
        {
            MintMark = mintMark;
        }

        public override string About()
        {
            return $"US {Name} is from {Year}. It is worth {MonetaryValue.ToString("c")}. It was made in {GetMintNameFromMark(MintMark)}";
        }

        public static string GetMintNameFromMark(USCoinMintMark m)
        {
            string output = String.Empty;
            switch (m)
            {
                case USCoinMintMark.D:
                    output = "Denver";
                    break;
                case USCoinMintMark.P:
                    output = "Philadephia";
                    break;
                case USCoinMintMark.S:
                    output = "San Francisco";
                    break;
                case USCoinMintMark.W:
                    output = "West Point";
                    break;
            }

            return output;
        }

        public static List<ICoin> GetUSCoinList()
        {
            ICoin penny = new Penny();
            ICoin nickel = new Nickel();
            ICoin dime = new Dime();
            ICoin quarter = new Quarter();
            ICoin halfDollarCoin = new HalfDollar();
            ICoin oneDollarCoin = new DollarCoin();

            List<ICoin> coinList = new List<ICoin>
            {
                {oneDollarCoin },
                {halfDollarCoin },
                {quarter },
                {dime },
                {nickel },
                {penny }
            
            };

            return coinList.OrderByDescending(c => c.MonetaryValue).ToList();

        }
    }
}
