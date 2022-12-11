using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class TwoHundredPesosBankNote : MEXBankNote
    {
        public TwoHundredPesosBankNote() : this(MXWaterMark.JIC){ }
        public TwoHundredPesosBankNote(MXWaterMark m) 
        {
            Name = "200 pesos";
            MonetaryValue = 200.00;
            WaterMark = m;
        }
    }
}
