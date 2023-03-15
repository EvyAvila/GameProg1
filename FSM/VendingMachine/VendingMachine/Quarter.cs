using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    //based on Gum class
    public class Quarter
    {
        private static Quarter quarterInstance = null; //set instance
        private double Value = 0.25; //set the value for the quarter

        private Quarter() { }

        //this will be called and set the instance once
        public static Quarter QuarterInstance 
        { 
            get 
            { 
                if(quarterInstance == null)
                {
                    quarterInstance = new Quarter();
                }

                return quarterInstance;
            } 
        }

        //get the value of the quarter that'll be used to insert into the machine
        public double InsertQuarter()
        {
            return Value;
        }
    }
}
