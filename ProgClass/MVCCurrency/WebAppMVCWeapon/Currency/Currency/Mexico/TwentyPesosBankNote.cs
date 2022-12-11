using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class TwentyPesosBankNote : MEXBankNote
    {
        public TwentyPesosBankNote() :this(MXWaterMark.BJ) { }
        public TwentyPesosBankNote(MXWaterMark m) 
        {
            Name = "20 pesos";
            MonetaryValue = 20.00;
            WaterMark = m;
        }
    }
}
