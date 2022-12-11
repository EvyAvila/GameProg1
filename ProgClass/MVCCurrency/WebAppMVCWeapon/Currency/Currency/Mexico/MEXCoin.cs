using CurrencyProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public enum MexicanCoinMintMark { OM } //This is the only place where the mint maark is located

    public abstract class MEXCoin : Coin
    {
        public MexicanCoinMintMark MXMintMark { get; set; } 
    
        public MEXCoin() { }

        public MEXCoin(MexicanCoinMintMark mXMintMark)
        {
            MXMintMark = mXMintMark;
        }

        public override string About()
        {
            //centavos means coin in Spanish
            return $"Mexican {Name} is from {Year}. It is worth {MonetaryValue.ToString("c")}. It was made in {WriteMintNameFromMake(MXMintMark)}";
        }

        public static string WriteMintNameFromMake(MexicanCoinMintMark m)
        {
            string output = String.Empty;
            switch (m)
            {
                case MexicanCoinMintMark.OM:
                    output = "La Casa de Moneda de México";
                    break;
            }

            return output;

        }

        public static List<ICoin> GetMXCoinList()
        {
            ICoin FiveC = new FiveCentCoin();
            ICoin TenC = new TenCentCoin();
            ICoin TwentyC = new TwentyCentCoin();
            ICoin FiftyC = new FiftyCentCoin();
            ICoin OnePC = new OnePesoCoin();
            ICoin TwoPC = new TwoPesosCoin();
            ICoin FivePC = new FivePesosCoin();
            ICoin TenPC = new TenPesosCoin();


            List<ICoin> coinList = new List<ICoin>
            {
                { TenPC },
                { FivePC },
                { TwoPC },
                { OnePC },
                { FiftyC },
                { TwentyC },
                { TenPC },
                { FiveC },
            };

            return coinList.OrderByDescending(c => c.MonetaryValue).ToList();
        }
    }
}
