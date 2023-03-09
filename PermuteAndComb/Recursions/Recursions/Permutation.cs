using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursions
{
    public class Permutation
    {
        List<string> InputList; //holds the input list 
        List<int> CalculationList = new List<int>(); //holds the numbers to calculate

        int CurrentNumber; //the current number of R (restriction)
        string Output; //displaying the output of the input list 
        int PermutationNumber; //the number that subtracts based on the current number

        public Permutation(List<string> input)
        {
            InputList = input;
            PermutationNumber = InputList.Count;
        }

        /// <summary>
        /// This method is a recursion that handles the calculates
        /// based on the number of the permutation. 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int Calculate(int num) //Based on in class demonstration 
        {
            if (num == 0)
            {
                //collects the items in the list can multiplies them all to get the total value
                int value = CalculationList.Aggregate((x, y) => x * y); //help from https://code.4noobz.net/multiply-all-elements-from-a-list/

                Console.WriteLine($"total of {InputList.Count} P {CurrentNumber} = " + value); //Write the total value

                List<string> permutationList = CreatePermList(); //setting the list from the created permutation

                //Display all permutations
                for (int i = 0; i < value; i++)
                {
                    Console.Write(permutationList[i] + " \n");
                }

                Console.WriteLine("\n");

                Reset();
                return 0; //condition to terminate
            }
            else
            {
                CalculationList.Add(PermutationNumber); //add the number into list for calcultation. 
                PermutationNumber--; //decrease value based on recursion of the current number
                return num * Calculate(num - 1); //recursion call
            }
        }

        //Extracted to remove clutter inside the Calculate method
        private List<string> CreatePermList()
        {
            //Section from https://www.codeproject.com/Questions/5164929/Csharp-picking-different-combinations-out-of-a-lis
            var allPossibleCombo = InputList.Permute().ToList(); //holds all the possible combinations 
            var permutationList = new List<string>(); //a temporary containment that'll hold the permutations

            //Looping through to add each possible combintation into through list joining the "," character
            foreach (var v in allPossibleCombo)
            {
                permutationList.Add(string.Join(",", v.Select(n => n.ToString()).ToArray()));
            }

            return permutationList;
        }

        //"Resetting" the values by clearing the calculation list and permutation number
        private void Reset()
        {
            CalculationList.Clear();
            PermutationNumber = InputList.Count;
        }

        //Displaying each permutation 
        public void DisplayPermutation()
        {
            foreach (var v in InputList) {  Output += v;  } //adding the element into string for each display

            Console.WriteLine("Input: " + Output); //displaying the element as output

            Console.ReadKey();

            foreach (var v in InputList) 
            {
                CurrentNumber += v.Length; //Setting the current number
                Console.WriteLine($"The current number is: {InputList.Count()}P{CurrentNumber}"); //display
                Calculate(CurrentNumber); //Start calculation

                //Console.ReadKey(); //add back in if needed

            }
        }

    }
}
