using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Mexico
{
    public class FiftyPesosBankNote : MEXBankNote
    {
        public FiftyPesosBankNote() :this(MXWaterMark.JMM) { }
        public FiftyPesosBankNote(MXWaterMark m) 
        {
            Name = "50 pesos";
            MonetaryValue = 50.00;
            WaterMark= m;
        }

    }
}
