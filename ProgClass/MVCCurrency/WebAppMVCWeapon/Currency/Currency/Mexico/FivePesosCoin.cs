using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Currency.Mexico
{
    public class FivePesosCoin : MEXCoin
    {
        public FivePesosCoin() : this(MexicanCoinMintMark.OM) { }

        public FivePesosCoin(MexicanCoinMintMark m)
        {
            Year = 2022;
            Name = "5 pesos";
            MonetaryValue = 5.00;
            MXMintMark = m;
        }
    }
}
