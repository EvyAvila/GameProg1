using System.Security.Principal;

namespace Recursions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> InputTest = new List<string>();// { "5", "4", "c", "#", "e" }; //test
            //List<string> InputTestWithDuplicates = new List<string> { "a", "a", "4", "!", "!" }; //testing with duplicates

            UserInput(InputTest); //Collect inputs

            ClearScreen();

            Console.WriteLine("Permutation");
            Permutation p = new Permutation(InputTest);
            p.DisplayPermutation();

            ClearScreen();

            Console.WriteLine("Order Partitions");
            OrderPartitions o = new OrderPartitions(InputTest);
            o.DisplayOrderPartitions();

            ClearScreen();

            Console.WriteLine("Combintation");
            Combintation c = new Combintation(InputTest);
            c.DisplayCombintation();

            Console.ReadKey();

        }

        /// <summary>
        /// This method mainly clears the screen after a key has been pressed. 
        /// </summary>
        private static void ClearScreen()
        {
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// This method is used to receive the user input and insert them into a 
        /// List containment. While looping, it checks the user input to
        /// see if there is only one character. If the user skips, a default
        /// value is placed. If the user inserts more than one character, the
        /// first character from the input is used only. After the end of
        /// the loop, it'll display the overall input from the user. 
        /// </summary>
        /// <param name="InputTest"></param>
        private static void UserInput(List<string> InputTest)
        {
            Console.WriteLine("Type 5 characters");
            string UserInput = string.Empty;
            for (int i = 0; i < 5; i++)
            {
                UserInput = Console.ReadLine();

                if (UserInput.Length == 0) //if no input
                {
                    InputTest.Add("5");
                }
                else if (UserInput.Length > 1) //if more than 1 character
                {
                    InputTest.Add(UserInput.Substring(0, 1)); //substring help from https://www.tutorialspoint.com/How-to-find-the-first-character-of-a-string-in-Chash#:~:text=How%20to%20find%20the%20first%20character%20of%20a%20string%20in%20C%23%3F&text=To%20get%20the%20first%20character%2C%20use%20the%20substring()%20method.&text=string%20str%20%3D%20%22Welcome%20to%20the,in%20the%20substring()%20method.https://www.tutorialspoint.com/How-to-find-the-first-character-of-a-string-in-Chash#:~:text=How%20to%20find%20the%20first%20character%20of%20a%20string%20in%20C%23%3F&text=To%20get%20the%20first%20character%2C%20use%20the%20substring()%20method.&text=string%20str%20%3D%20%22Welcome%20to%20the,in%20the%20substring()%20method.
                }
                else //meets requirement 
                {
                    InputTest.Add(UserInput);
                }
            }

            Console.WriteLine("Your input is:");
            foreach (var v in InputTest) //Display all input
            {
                Console.WriteLine(v);
            }
        }
    }


    //Class from https://www.codeproject.com/Questions/5164929/Csharp-picking-different-combinations-out-of-a-lis
    public static class Extensions
    {
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> sequence)
        {
            //Checks to see if the containment is empty, which will break out if so
            if (sequence == null)
            {
                yield break;
            }

            //Create a temporary list from the inserted sequence
            var list = sequence.ToList();

            if (!list.Any()) //double checks if the list doesn't contain anything inside, will keep looping 
            {
                yield return Enumerable.Empty<T>();
            }
            else
            {
                var startingElementIndex = 0; //setting the value of the starting index to check out the first element, which is always in 0 position
                foreach (var startingElement in list)
                {
                    var remainingItems = list.Where((e, i) => i != startingElementIndex); //get the remaining items from the list that is after the 0 position

                    foreach (var permutationOfRemainder in remainingItems.Permute()) //looping through while calling itself to get each element
                    {
                        yield return startingElement.Concat(permutationOfRemainder); //connect the first element with the rest of the elements
                    }

                    startingElementIndex++;
                }
            }
        }

        //combining the text from multiple strings into each permutation
        private static IEnumerable<T> Concat<T>(this T firstElement, IEnumerable<T> secondSequence)
        {
            yield return firstElement;
            if (secondSequence == null) //stop until the sequence inside is empty
            {
                yield break;
            }

            foreach (var item in secondSequence) //looping through to add the next elements in the sequence
            {
                yield return item;
            }
        }

        
        
    }

   
}