using System;

namespace OOP
{

    public class Program
    {

        public static void Main()
        {
            try
            {
                // Deletes any previous data in the console
                Console.Clear();
                Console.WriteLine("Welcome to the UFV Train Station Management System");
                Console.WriteLine("");

                // We ask the user how many platforms he wants to create for the train station
                Console.WriteLine("How many platforms does the train station have: ");
                int numberPlatforms = int.Parse(Console.ReadLine());

                // Instantation and passing the desired number of platforms
                Station station = new Station(numberPlatforms);

                /* As such there's not a limit on the number of platfroms however entering a realistic example 
                is recommened, as it is not possible to make a station to have for example 50 platforms. */

                station.PrintMenu(); // Print the options menu
            }
            catch (ArgumentNullException ex0)
            {
                Console.WriteLine($"An error has been detected: {ex0.Message}");
                Console.WriteLine("Please try again by executing the program again and enter a valid number");
            }
            catch (FormatException ex1)
            {
                Console.WriteLine($"An error has been detected: {ex1.Message}");
                Console.WriteLine("Please try again by executing the program again and enter a valid number");
            }
        }
    }
}