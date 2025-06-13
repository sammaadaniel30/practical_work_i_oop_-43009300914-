using System;

namespace OOP
{

    public class Program
    {

        public static void Main()
        {

            Console.WriteLine("Welcome to the UFV Train Station Management System");
            Console.WriteLine("");

            // We ask the user how many platforms he wants to create for the train station
            Console.WriteLine("How many platforms does the train station have: ");
            int numberPlatforms = int.Parse(Console.ReadLine());

            // Instantation and passing the desired number of platforms
            Station station = new Station(numberPlatforms);

            station.PrintMenu(); // Print the options menu



             

        }
    }
}