using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class TenPesosCoin : MEXCoin
    {
        public TenPesosCoin() : this(MexicanCoinMintMark.OM) { }

        public TenPesosCoin(MexicanCoinMintMark m)
        {
            Year = 2022;
            Name = "10 pesos";
            MonetaryValue = 10.00;
            MXMintMark = m;
        }
    }
}
