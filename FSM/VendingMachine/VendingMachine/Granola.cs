using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    //based on Gum class
    public class Granola
    {
        private static Granola granolaInstance = null; //set instance
        private double Cost = 0.75; //price for the granola

        private Granola() { }

        //this will be called and set the instance once
        public static Granola GranolaInstance
        {
            get
            {
                if (granolaInstance == null)
                {
                    granolaInstance = new Granola();
                }
                return granolaInstance;
            }
        }

        //this is a string that'll display the cost of the granola : $0.75 instead of 0.75
        public string DisplayCost()
        {
            return Cost.ToString("c");
        }

        //get the number of the cost for calculation
        public double CostValue()
        {
            return Cost;
        }
    }
}
