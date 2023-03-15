using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    //States:
    /*
     Wait - inital state of the vending machine waiting for any input
     MakeSelection - state where the vending machine will retrieve the item based on the input selection (ei, gum or granola)
     ReturnItem - state where the vending machine has "dropped" the item for the user to pick up
     ReceiveMoney - state where the vending machine is receiving the money the user "inserts" to buy
     Close - the final state that'll end the use of the vending machine and close the application
     */
    public enum VendStates { Wait, MakeSelection, ReturnItem, ReceiveMoney, Close }

    public class VendMachine
    {
        //Instantiated once
        Gum gum = Gum.GumInstance;
        Granola granola = Granola.GranolaInstance;
        Quarter quarter = Quarter.QuarterInstance;
        Item item = Item.ItemInstance;
        
        //access to the different states
        VendStates states;

        //the total value of currency inside the vending machine
        double TotalValue;
        
        //Inputs that the user will choose and change the vending machine state
        private string[] Inputs = new string[] { "Pay", "Select", "Retrieve item", "Exit"  };

       
        public VendMachine() {   }

        //Method to be called in Program class to start running
        public void UseVendingMachine()
        {
            DisplayInformation();
        }

        //Main method that displays important text, waiting for user input,
        //and enter the next method.
        private void DisplayInformation()
        {
            Console.WriteLine($"Gum Price: {gum.DisplayCost()}");
            Console.WriteLine($"Granola Price: {granola.DisplayCost()}");

            Console.WriteLine("Vending Machine Total Currency: " + TotalValue.ToString("c"));

            Console.WriteLine("Select an option by typing the number:");
            for(int i = 0; i < Inputs.Length; i++)
            {
                Console.Write($"{i+1}) {Inputs[i]} \n");
            }

            string UserInput = Console.ReadLine().Trim();
            HandleInput(UserInput);
        }

        //Method that first checks if the input is a number
        //If so, change the state of the vending machine 
        //based on the user input. Afterwards, handle the
        //next action based on the state
        private void HandleInput(string input)
        {
            //help from https://www.arungudelli.com/tutorial/c-sharp/check-if-string-is-number/
            var stringNumber = input; //get the string value
            int numericValue; //number value
            bool isNumber = int.TryParse(stringNumber, out numericValue); //try parse is to check if the input was able to convert to a number. If so, bool is true
           
            //if the bool is false, also known as not a number, return back to the beginning
            //to insert correct option
            if(!isNumber )
            {
                Console.Clear();
                DisplayInformation();
            }

            // "Pay", "Select", "Retrieve", "Exit" 
            switch (input)
            {
                case "1": //pay machine
                    states = VendStates.ReceiveMoney; //Receive money from user
                    break;
                case "2": //select item
                    states = VendStates.MakeSelection; //give user item
                    break;
                case "3": //retrieve
                    states = VendStates.ReturnItem; //give any change back
                    break;
                case "4": //close or exit vending machine
                    states = VendStates.Close; //stop the use of vending machine
                    Console.WriteLine("Goodbye");
                    Console.ReadKey();
                    break;
                default:
                    states = VendStates.Wait; 
                    ReturnToVendMachine(); //any other inputs results going back to the "main menu"
                    break;
            }

            //Start method based on the state
            GetState(states);

        }

        //An extracted method. Mainly to reuse 
        //clearing and returning back to the "main menu"
        private void ReturnToVendMachine()
        {
            Console.Clear();
            DisplayInformation();
        }

        //Check the states and enter the method
        private VendStates GetState(VendStates currentState)
        {
            switch (currentState)
            {
                case VendStates.ReceiveMoney:
                    InsertMoney();
                    break;
                case VendStates.MakeSelection:
                    Console.Clear();
                    SelectItem();
                    break;
                case VendStates.ReturnItem:
                    PickUpItem();
                    break;
            }

            //While the state is not Close, "loop" through the application 
            if(states != VendStates.Close)
            {
                ReturnToVendMachine();
            }
            
            return currentState;

        }

        //This method is interting the money into the vending machine
        private void InsertMoney()
        {
            //If the user hasn't picked an item yet, add the quarters into the machine
            if (item.ItemName() == null)
            {
                TotalValue += quarter.InsertQuarter();
            }
            else //else, display that the user has already paid and must pick up the item before making another purchase
            {
                Console.WriteLine("You must retrieve your item before using the machine again");
                Console.ReadKey();
                ReturnToVendMachine();
            }

                
        }

        //This section allows the user to pick the option for the available products
        private void SelectItem()
        {
            //If the user has already made their selection, they can't choose another item
            if (item.ItemName() != null)
            {
                Console.WriteLine("You have already made a selection. Please pick up item");
                Console.ReadKey();
                ReturnToVendMachine();
            }

            //Display
            Console.WriteLine("Insert the following selection:");
            Console.WriteLine($"1) Gum - Price: {gum.DisplayCost()}");
            Console.WriteLine($"2) Granola - Price: {granola.DisplayCost()}");

            //Fame concept of checking if the input is a number
            string output = Console.ReadLine();
            int numericValue;
            bool isNumber = int.TryParse(output, out numericValue);

            //If input was not a number, call method again
            if (!isNumber)
            {
                Console.Clear();
                SelectItem();
            }

            //Make the appropriate calculation based on the selected option
            switch(output)
            {
                case "1":
                    Calculate(gum.CostValue(), "Gum"); //gets the gum cost value
                    break;
                case "2":
                    Calculate(granola.CostValue(), "Granola"); //gets the granola cost value
                    break;
                default:
                    ReturnToVendMachine();
                    break;
            }

        }

        //Check to see if the machine was inserted enough money to buy.
        //If so, reduce the total value from the cost and set the item
        //name to the product
        void Calculate(double cost, string product)
        {
            if (TotalValue < cost)
            {
                Console.WriteLine("Not enough money");
            }
            else
            {
                TotalValue -= cost;
                item.RetrieveItem(product);
                Console.WriteLine(item.ItemName() + " has dropped.");
            }
            Console.ReadKey();

        }

        //A method that checks if the item is null, the user can't pick anything up
        //Else, they "pick up" the item, return any change, and reset the item to be null 
        void PickUpItem()
        {
            if(item.ItemName() == null) //if there is no item to pick
            {
                Console.WriteLine("There is no item to retrieve");
                Console.ReadKey();
            }
            else //if there is an item to pick
            {
                Console.WriteLine("You have picked up " + item.ItemName());
                ReturnChange();

                Console.ReadKey();
                item.ResetItem();
            }
        }

        //A method that checks if there were any money left over from the user
        void ReturnChange()
        {
            if (TotalValue == 0) //if the total value is 0, meaning it was exact amount
            {
                Console.WriteLine("No change returned");
            }
            else //return the rest of extra money and set the TotalValue to 0
            {
                Console.WriteLine("Returned: " + TotalValue.ToString("c"));
                TotalValue = 0;
            }
        }
       
    }
}
