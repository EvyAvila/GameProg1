using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursions
{
    public class Combintation
    {
        List<string> InputList; //holds the input list 
        string Output; //displaying the output of the input list 
        int CurrentNumber; //the current number of R (restriction)
        int TotalNthNumber; //getting the total value from the nth value. EX: n = 5 -> 5*4*3*2*1 = 120

        public Combintation(List<string> input) 
        {
            InputList = input;
            TotalNthNumber = GetNthTotal(); //Setting the nth value for future calculation
        }

        /// <summary>
        /// Method that calculates to display the combinations
        /// </summary>
        private void Calculate()
        {
            List<int> combList = new List<int>(); //a temporary list to hold the calculations from the current number
            List<int> differenceList = new List<int>(); //a temporary list to hold the calculations from the difference 

            int combNumber = CurrentNumber; //holds the current number of the R value
            int calcDifference = InputList.Count - combNumber; //holds the math difference from N and R: EX: 5C1 -> 5-1 = 4 => r = 4 

            Console.WriteLine($"5! / {combNumber}! * {calcDifference}! ");

            int tempCombNumber = combNumber;                //Both are holding a temporary value 
            int tempCalcDifference = calcDifference;        //for when the list are adding the values and decreasing


            while (combList.Count() < combNumber) //loop to add the restriction value into the list
            {
                combList.Add(tempCombNumber);
                tempCombNumber--;
            }

            int firstValue = combList.Aggregate((x, y) => x * y); //get the total value from the restriction list

            while (differenceList.Count() < calcDifference) //loop to add the difference value into the list
            {
                differenceList.Add(tempCalcDifference);
                tempCalcDifference--;
            }

            int secondValue; 
            if (differenceList.Count() == 0)                                //check to see if the list is 0, set the value as 0
            {                                                               //otherwise, calculate the elements inside the difference list
                secondValue = 0;
            }
            else
            {
                secondValue = differenceList.Aggregate((x, y) => x * y);
            }

            int RthValue = firstValue * secondValue; //get the overall Rth total from multiplying the first value and the second


            if (RthValue == 0) //This method is mainly used to check if the RthValue is 0, set total to 1 since 0 can't be divided
            {
                RthValue = firstValue;
            }

            int Result = TotalNthNumber / RthValue; //Get the overall result from calculations


            Console.WriteLine($"{TotalNthNumber} / {firstValue} * {secondValue} "); //Display
            Console.WriteLine($"Result: {Result} ");


            CreateCombo(combNumber); //Create the combinations

        }

        //Displaying each combinations
        public void DisplayCombintation()
        {
            foreach (var v in InputList) { Output += v; } 
            Console.WriteLine("Input: " + Output); //displaying the elements

            foreach (var v in InputList) 
            {
                CurrentNumber += v.Length; //set the current number
                Console.WriteLine($"{InputList.Count}C" + CurrentNumber); //display
                Calculate(); //Start calculation
            }
        }

        //method with alternations from https://stackoverflow.com/questions/16478716/how-to-make-combination-based-on-limit-provided
        
        void CreateCombo (int k)
        {
            int limit = k; //Get the limit for each combo, also known as the R (restricted) value
            var result = Combinations(InputList.ToArray(), limit); //Get the combination based on the limit and individual elements found within the list containments
            foreach(var c in result) //loop through and display each result while joining the string while separating the combinations with the ","
            {
                Console.WriteLine(String.Join(",", c.Select(a => a.ToString()).ToArray()) );
            }
           
        }

        //method from https://stackoverflow.com/questions/16478716/how-to-make-combination-based-on-limit-provided
        public static IEnumerable<IEnumerable<T>> Combinations<T>(IEnumerable<T> elements, int k) //used IEnumerable as a way to organize containments
        {
            //First checks to see if the number/limit/k is 0, which won't create the element as there is no determine restriction. Thus returning 
            //an empty containment             
            return k == 0 ? new[] { new T[0] } : 
                elements.SelectMany((e, i) => //otherwise, check each element and number based on the size of the IEnumaerable elements
                Combinations(elements.Skip(i + 1), k - 1).Select(c => (new[] { e }).Concat(c))); //then, skipping the next element to create the other combintation by the limit size and add them to the end of the element
            /*
             EX: 5,4,@, a, b with 5C2
                elements = 54@ab
                select -> 5
                Skip to next -> 4
                Get the size of limitation -> 2 - 1 = 1, so only one value can be added next to the first element
                Add them to the array and combind them 

             */
        }

      

        /// <summary>
        /// A method that returns the total size number based on the length of the list. 
        /// </summary>
        /// <returns></returns>
        private int GetNthTotal()
        {
            List<int> tempCal = new List<int>(); //a temporary list to hold each number 
            int total = 0; //setting the total to 0 as the base

            if (tempCal.Count == 0) //checks to see if the list is empty
            {
                for (int i = InputList.Count; i > 0; i--) //Starts at the highest length and decreases over looping
                {
                    tempCal.Add(i); //add the number into the list
                }

                total = tempCal.Aggregate((x, y) => x * y); //calculate the total inside the list. EX: 5*4*3*2*1
            }

            return total; //return number
        }

    }
}

#region Checking Calculations
//5C1 = 5
//5! / 1! (5-1)!
//5! / 1! * 4! -> 1 * 4*3*2*1
//5! / 1 * 24
//120 / 24 = 5

//5C2 = 10 
//5! / 2! (5-2)!
//5! / 2! * 3! -> 2*1 * 3*2*1
//5! / 2 * 6
//120 / 12 = 10

//5C3 = 10
//5! / 3! (5-3)!
//5! / 3! * 2!

//5C4 = 5
//5! / 4! (5-4)!
//5! / 4! * 1!

//5C5 = 1
//5! / 5! (5-5)!
//5! / 5! * 0!

#endregion
