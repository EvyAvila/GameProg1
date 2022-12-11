using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class OnePesoCoin : MEXCoin
    {
        public OnePesoCoin() : this(MexicanCoinMintMark.OM){ }

        public OnePesoCoin(MexicanCoinMintMark m)
        {
            Year = 2022;
            Name = "1 peso";
            MonetaryValue = 1.00;
            MXMintMark = m;
        }
    }
}
