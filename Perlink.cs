using System;
using System.Collections.Generic;

namespace Perlink
{
    class NumberClassificator
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert a number to be classified or 0 to quit");

            //check if input is an integer
            int number;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ilegal number");
                string[] args1 = { };
                Main(args1);
                return;
            }
            if (number == 0)
            {
                return;
            }

            NumberClassificator classificator = new NumberClassificator();

            //Test if the number is a happy number
            if (classificator.isHappyNumber(number))
            {
                Console.WriteLine(number + " is a happy number");
            }
            else
            {
                Console.WriteLine(number + " is NOT a happy number");
            }

            //Test if the number is a lucky number
            if (classificator.isLuckyNumber(number))
            {
                Console.WriteLine(number + " is a lucky number");
            }
            else
            {
                Console.WriteLine(number + " is NOT a lucky number");
            }

            //try again
            string[] args2 = { };
            Main(args2);
            return;

        }

        Boolean isHappyNumber(int number)
        {
            Boolean isHappy = false;

            
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                IEnumerable<int> digitsEnum = GetDigits(number);
                foreach (int digit in digitsEnum)
                {
                    sum += digit * digit;
                }
                if (sum == 1)
                {
                    isHappy = true;
                    break;
                }

                number = sum;
                sum = 0;
            }
            return isHappy;
        }

        Boolean isLuckyNumber(int number)
        {
            Boolean isLucky = false;

            if(number == 1)
            {
                return true;
            }
            else
            {
                List<int> numberList = new List<int>();

                //build inital list
                for (int i = 1; i <= number + 10; i++)
                {
                    numberList.Add(i);
                }


                //build list after removing elements
                int currentPositionSpaceBetween = 1;
                Boolean is2 = true;
                while (currentPositionSpaceBetween < numberList.Count)
                {
                    int currentPositionToRemove = numberList[currentPositionSpaceBetween];
                    int indexToRemove = currentPositionToRemove;

                    //put 0 in the positions to be removed
                    while (currentPositionToRemove < numberList.Count)
                    {
                        numberList[currentPositionToRemove - 1] = 0;                 
                        currentPositionToRemove += indexToRemove;
                    }

                    //remove 0s
                    numberList.RemoveAll(item => item == 0);

                    //change position for elements diferents of 2
                    if(!is2)
                    {
                        currentPositionSpaceBetween++;
                    }
                    is2 = false; 
                    
                }

                //check if number is in the final list
                for (int i = 0; i < numberList.Count; i++)
                {
                    if(number == numberList[i])
                    {
                        isLucky = true;
                        break;
                    }
                }
            }
            
            return isLucky;
        }

        public static IEnumerable<int> GetDigits(int source)
        {
            Stack<int> digits = new Stack<int>();
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                digits.Push(digit);
            }

            return digits;
        }
    }
}
