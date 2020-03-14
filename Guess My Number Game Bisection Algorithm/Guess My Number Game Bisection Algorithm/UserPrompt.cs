using System;
using System.Collections.Generic;
using System.Text;

namespace Guess_My_Number_Game_Bisection_Algorithm
{
    class UserPrompt
    {
        //The bisection method is an efficient way of finding a particular value in a sorted list. It takes a sorted list and a value, and finds the value in the list. First, it checks the “middle” element in the list. There are three possibilities: the value could match the “middle” element, the value could be higher than the ‘middle” element of the list, or the value could be lower than the “middle” element. If the value matches, the function returns. If it’s higher, the algorithm (recursively) calls itself with the top half of the list. If it’s lower, the algorithm calls itself with the bottom half of the list.
        //For example, here is the output of a function call, the searched value being 7 and the sorted list being[1 2 3 4 5 6 7 8 9 10].
        int userInput;
        public void Run()
        {
            Console.WriteLine("The bisection algorithm is nice because it is guaranteed to find an answer (or return if there is no answer) in logarithmic time of the size of the list");
            Console.WriteLine("Of an integer array from 1 to 10:");
            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int num in list)
            {
                Console.Write($"{num}, ");
            }
            Console.WriteLine();
            Console.WriteLine("Select a number from 1 to 10:");
            userInput = ElicitInput();
            Console.WriteLine($"You chose :{userInput}");
            Console.WriteLine(new BisectionAlgorithm().Bisect(userInput, list));
        }
        private static int ElicitInput()
        {
            int inputAsInt = 0;

            for (bool validInput = false; !validInput;)
            {
                Console.Write("Type an integer: ");

                var input = Console.ReadLine();
                validInput = int.TryParse(input, out inputAsInt);
            }

            return inputAsInt;
        }
    }
}
