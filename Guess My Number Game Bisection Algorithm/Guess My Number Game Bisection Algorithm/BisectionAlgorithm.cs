using System;
using System.Collections.Generic;
using System.Text;

namespace Guess_My_Number_Game_Bisection_Algorithm
{
    class BisectionAlgorithm
    {
        public bool Bisect(int userInput, int[] array)
        {
            bool correct = false;
            if (array.Length % 2 == 0)//num elements is even; there is no single middle number, but a pair
            {
                Console.WriteLine($"Is it {array[array.Length / 2]}?");
                if (userInput == array[array.Length / 2])//the higher of the pair
                {
                    correct = true;
                }
                else if (userInput < array[array.Length / 2])
                {
                    Console.WriteLine("That's too high?  Well then...");
                    int[] nextArray = new int[array.Length / 2];
                    for (int i = 0; i < nextArray.Length; i++)
                    {
                        nextArray[i] = array[i];
                    }
                    correct = new BisectionAlgorithm().Bisect(userInput, nextArray);
                }
                else if (userInput > array[array.Length / 2])
                {
                    Console.WriteLine("That's too low?  Well then...");
                    int[] nextArray = new int[(array.Length / 2) - 1];
                    for (int i = 0; i < nextArray.Length; i++)
                    {
                        nextArray[i] = array[i + nextArray.Length+2];
                    }
                    correct = new BisectionAlgorithm().Bisect(userInput, nextArray);
                }
            }
            else //num elements is odd; (array.length/2) gives the middle index as index n gives the n+1th element
            {
                Console.WriteLine($"Is it {array[array.Length / 2]}?");
                if (userInput == array[array.Length / 2])
                {
                    correct = true;
                }
                else if (userInput < array[array.Length / 2])
                {
                    Console.WriteLine("That's too high?  Well then...");
                    int[] nextArray = new int[array.Length / 2];
                    for (int i = 0; i < nextArray.Length; i++)
                    {
                        nextArray[i] = array[i];
                    }
                    correct = new BisectionAlgorithm().Bisect(userInput, nextArray);
                }
                else if (userInput > array[array.Length / 2])
                {
                    Console.WriteLine("That's too low?  Well then...");
                    int[] nextArray = new int[array.Length / 2];
                    for (int i = 0; i < nextArray.Length; i++)
                    {
                        nextArray[i] = array[i + nextArray.Length + 1];
                    }
                    correct = new BisectionAlgorithm().Bisect(userInput, nextArray);
                }
            }
            return correct;
        }
        public bool CheckUserInput(int userInput, int compuNum)
        {
            bool correct = false;
            Console.WriteLine($"{userInput}, huh?  Well...");
            if (userInput == compuNum)
            {
                Console.WriteLine("That's correct!");
                correct = true;
            }
            else if (userInput > compuNum)
            {
                Console.WriteLine("That's too high!");
            }
            else
            {
                Console.WriteLine("That's too low!");
            }
            return correct;
        }
    }
}
