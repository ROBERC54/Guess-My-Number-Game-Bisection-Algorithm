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
        public void Intro()
        {
            Console.WriteLine("The bisection algorithm is nice because it is guaranteed to find an answer (or return if there is no answer) in logarithmic time of the size of the list");
            Console.WriteLine("Of an integer array from 1 to 10:");
            int[] list = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int num in list)
            {
                Console.Write($"{num}, ");
            }
            Console.WriteLine();
            userInput = EnforceBounds(1, 10);
            Console.WriteLine($"You chose :{userInput}");
            new BisectionAlgorithm().Bisect(userInput, list);
        }
        public void HumanPlay()
        {
            Random prng = new Random();
            int compuNum = prng.Next(1, 1000);
            int[] list = new int[1000];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = i + 1;
            }
            Console.WriteLine("The computer will randomly select a number between 1 and 1000.  Try and guess it!");
            int guessesOne = 0;
            for (bool foundCompuNum = false; !foundCompuNum;guessesOne++)
            {
                userInput = EnforceBounds(1, 1000);
                Console.WriteLine($"You chose :{userInput}");
                foundCompuNum = new BisectionAlgorithm().CheckUserInput(userInput, compuNum);
            }
            Console.WriteLine($"Congratulations!  It took {guessesOne} guesses!  Let's try again!");
            compuNum = prng.Next(1, 1000);
            Console.WriteLine("The computer will randomly select a number between 1 and 1000.  Try and guess it!");
            int guessesTwo = 0;
            for (bool foundCompuNum = false; !foundCompuNum; guessesTwo++)
            {
                userInput = EnforceBounds(1, 1000);
                Console.WriteLine($"You chose :{userInput}");
                foundCompuNum = new BisectionAlgorithm().CheckUserInput(userInput, compuNum);
            }
            Console.WriteLine($"Congratulations!  It took {guessesTwo} guesses!  Your average is {(guessesOne+guessesTwo)/2}!");
        }
        private static int EnforceBounds(int lowerBound, int upperBound)
        {
            int userInput=0;
            for (bool validInput = false; !validInput;)
            {
                Console.WriteLine($"Select a number from {lowerBound} to {upperBound}:");
                userInput = ElicitInput();
                if (userInput >= lowerBound)
                {
                    if (userInput <= upperBound)
                    { validInput = true; }
                }
            }
            return userInput;
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
