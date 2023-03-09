using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursions
{
    public class OrderPartitions
    {
        List<string> InputList; //holds the input list 

        List<string> UniqueOnlyList; //holds the unique characters only

        public OrderPartitions(List<string> input)
        {
            InputList = input;
            UniqueOnlyList = new List<string>();
            CheckForDuplicates(); 
        }

        /// <summary>
        /// This method is mainly used to check for duplicates found from
        /// the input list. First, add the first input into the list. Then,
        /// loop through to check if the list doesn't contain a unique character
        /// </summary>
        private void CheckForDuplicates()
        {
            UniqueOnlyList.Add(InputList[0]);

            for (int i = 0; i < InputList.Count; i++) //method based on suggestion/help from Duncan Mcdonald
            {
                if (!UniqueOnlyList.Contains(InputList[i]))
                {
                    UniqueOnlyList.Add(InputList[i]);
                }
                
            }
        }

        //Displaying the ordered partitions
        public void DisplayOrderPartitions()
        {
            Console.WriteLine("Unique characters: ");
            foreach (string input in UniqueOnlyList) //display the unique characters
            {
                Console.WriteLine(input);
            }

            //Section from https://www.codeproject.com/Questions/5164929/Csharp-picking-different-combinations-out-of-a-lis
            var allPossibleCombo = InputList.Permute().ToList(); //holds all the possible combinations 
            var permutationList = new List<string>(); //a temporary containment that'll hold the permutations

            //Looping through to add each possible combintation into through list joining the "," character
            foreach (var v in allPossibleCombo)
            {
                permutationList.Add(string.Join(",", v.Select(n => n.ToString()).ToArray()));  
            }

            List<string> temp = new List<string>(); //another temporary containment to check for duplicate permutations
            for (int i = 0; i < permutationList.Count; i++) 
            {
                if (!temp.Contains(permutationList[i])) //checks if list doesn't contain a duplicate permutation
                {
                    temp.Add(permutationList[i]);
                }

            }

            foreach (var v in temp) //display each value in the list
            {
                Console.WriteLine(v);
            }

            int length = temp.Count; //getting the length of the list with the removed duplicates, which equals to the formula. EX: 5!/2! * 2! = 30, with the list count = 30
            Console.WriteLine("Total is: " + length); //Display total

            
        }

        /* Checking result values based on formula
        n! / ( r1!*r2!....*rk!) 
        5! / 2! * 2! 
        120 / 2 * 2
        120 / 4 = 30

         */

    }
}
