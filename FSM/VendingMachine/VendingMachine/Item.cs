using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    //based on Gum class
    public class Item
    {
        private static Item itemInstance = null; //set instance
        private string itemName = null; //set the string value to null
        

        private Item() { }

        //this will be called and set the instance once
        public static Item ItemInstance 
        {
            get
            {
                if(itemInstance== null)
                {
                    itemInstance = new Item();
                }

                return itemInstance;
            }
        }

        //Set the name of the product into itemName
        public string RetrieveItem(string product)
        {
            if(itemName == null)
            {
                itemName = product;
            }

            return itemName;
        }

        //read the string
        public string ItemName()
        {
            return itemName;
        }

        //reset the string to null
        public string ResetItem()
        {
            itemName = null;
            return itemName;
        }
    }
}
