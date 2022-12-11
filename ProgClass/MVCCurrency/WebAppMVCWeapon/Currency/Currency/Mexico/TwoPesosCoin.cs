using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class TwoPesosCoin : MEXCoin
    {
        public TwoPesosCoin() : this(MexicanCoinMintMark.OM) { }

        public TwoPesosCoin(MexicanCoinMintMark m)
        {
            Year = 2022;
            Name = "2 pesos";
            MonetaryValue = 2.00;
            MXMintMark = m;
        }
    }
}
