using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    //Created class based on https://www.tutorialsteacher.com/csharp/singleton
    //with minor changes
    public class Gum 
    {
        private static Gum gumInstance = null; //set instance
        private double Cost = 0.50; //price for the gum

        private Gum() { }

        //this will be called and set the instance once
        public static Gum GumInstance
        {
            get
            {
                if(gumInstance == null)
                {
                    gumInstance = new Gum();
                }

                return gumInstance;
            }
            
        }

        //this is a string that'll display the cost of the gum : $0.50 instead of 0.5
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
