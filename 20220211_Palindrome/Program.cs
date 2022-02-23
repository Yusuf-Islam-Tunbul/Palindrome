using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20220211_Palindrome
{
    class Program
    {
        static Program program = new Program();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Lütfen pozitif bir tam sayı giriniz.");

                int number=program.GetNumber();


                if (program.CheckForPalindrome(number))
                {
                    Console.WriteLine("\nGirdiğiniz sayı bir palindromdur.");
                }

                else
                {
                    Console.WriteLine("\nGirdiğiniz sayı bir palindrom değildir.\n");
                }
            }
        }

        int GetNumber()
        {
            bool valid = false;
            int number = 0;

            while (!valid)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }

                else
                {
                    try
                    {
                        number = Convert.ToInt32(input);

                        if (number <= 0)
                        {
                            Console.WriteLine("\nOlmadı. Lütfen pozitif bir tam sayı giriniz.");
                        }

                        else
                        {
                            valid = true;
                        }
                    }
                    catch (OverflowException oe)
                    {
                        Console.WriteLine("\nOlmadı. Lütfen daha kısa, pozitif bir tam sayı giriniz.");
                    }
                    catch (FormatException fe)
                    {
                        Console.WriteLine("\nOlmadı. Lütfen pozitif bir tam sayı giriniz.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            return number;
        }

        bool CheckForPalindrome(int number)
        {
            bool is_palindrome = false;

            int[] digits = program.GetDigits(number);

            int new_number = program.GetNewNumber(digits);

            if (number == new_number)
            {
                is_palindrome = true;
            }

            return is_palindrome;
        }

        int[] GetDigits(int number)
        {
            int[] digits = new int[0];

            while (number >= 1)
            {
                digits = digits.Append(number % 10).ToArray();
                number /= 10;
            }

            return digits;
        }

        int GetNewNumber(int[] digits)
        {
            int new_number = 0;
            int multiplier = 1;

            foreach (int digit in digits.Reverse())
            {
                new_number += digit * multiplier;
                multiplier *= 10;
            }

            return new_number;
        }
    }
}
