using System;
using System.Collections.Generic;
using System.Text;

namespace Guess_My_Number_Game_Bisection_Algorithm
{
    class BisectionAlgorithm
    {
        public bool Bisect(int userInput, int[] array)
        {//searches for users number
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
        {//determines if a user's guess is correct, high, or low
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
        public int CompGuesses(int[] array)
        {
            int guesses = 1;
            if (array.Length != 1)
            {
                Console.WriteLine($"Is it {array[array.Length / 2]}?");
                Console.WriteLine("-- 'c' -- Correct  -- 'h' -- Too High  -- 'l' -- Too Low");
                int[] nextArray;
                ConsoleKey choice = Console.ReadKey().Key;
                switch (choice)
                {
                    case ConsoleKey.C:
                        break;
                    case ConsoleKey.H://reduces options to lower half
                        Console.WriteLine("That's too high?  Well then...");
                        nextArray = new int[array.Length / 2];
                        for (int i = 0; i < nextArray.Length; i++)
                        {
                            nextArray[i] = array[i];
                        }
                        guesses += new BisectionAlgorithm().CompGuesses(nextArray);
                        break;
                    case ConsoleKey.L:
                        Console.WriteLine("That's too low?  Well then...");
                        if (array.Length % 2 == 0)//num elements is even; there is no single middle number, but a pair
                        {
                            nextArray = new int[(array.Length / 2) - 1];
                            for (int i = 0; i < nextArray.Length; i++)
                            {
                                nextArray[i] = array[i + nextArray.Length + 2];
                            }
                            guesses += new BisectionAlgorithm().CompGuesses(nextArray);
                        }
                        else
                        {
                            nextArray = new int[array.Length / 2];
                            for (int i = 0; i < nextArray.Length; i++)
                            {
                                nextArray[i] = array[i + nextArray.Length + 1];
                            }
                            guesses += new BisectionAlgorithm().CompGuesses(nextArray);
                        }
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"There's only one option left, so it must be {array[array.Length / 2]}!");
            }
            return guesses;
        }
    }
}
