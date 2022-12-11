using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class TwentyCentCoin : MEXCoin
    {
        public TwentyCentCoin() : this(MexicanCoinMintMark.OM) { }

        public TwentyCentCoin(MexicanCoinMintMark m)
        {
            Year = 2022;
            Name = "20 centavos";
            MonetaryValue = 0.20;
            MXMintMark = m;
        }
    }
}
