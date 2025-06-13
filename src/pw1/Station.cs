using System;

namespace OOP
{
    public class Station
    {
        public List<Platform> platforms { get; set; }
        public List<Train> trains { get; set; }

        public int minutesPerTick = 15; // Each tick represents 15 minutes

        public Station(int numberOfPlatforms)
        {
            platforms = new List<Platform>();
            trains = new List<Train>();

            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                platforms.Add(new Platform($"Platform-{i}"));
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("___________________________________");
            Console.WriteLine("|+++++++++++ Train UFV +++++++++++|");
            Console.WriteLine("|---------------------------------|");
            Console.WriteLine("| Choose an option                |");
            Console.WriteLine("| 1. Load trains from file        |");
            Console.WriteLine("| 2. Load train manually          |");
            Console.WriteLine("| 3. Start simulation             |");
            Console.WriteLine("| 4. Exit                         |");
            Console.WriteLine("|---------------------------------|");
            Console.WriteLine("|+++++++++++++++++++++++++++++++++|");
            Console.WriteLine("|---------------------------------|");

            SelectOption(); 

        }

        public void SelectOption()
        {
            Console.WriteLine(" ");
            Console.WriteLine("Please select your option ");

            int selection = int.Parse(Console.ReadLine());

            if (selection == 1)
            {
                // Loads the file
                Console.WriteLine("You have selected to load the trains from files option");
            }
            else if (selection == 2)
            {
                Console.WriteLine("You have selected to load the trains manually");
            }
            else if (selection == 3)
            {
                Console.WriteLine("You have selected to load the trains from a file");

            }
            else if (selection == 4)
            {
                Console.WriteLine("The program will exit");
            }
            else 
            {
                Console.WriteLine("Invalid option. Please try again");
                PrintMenu(); 
            }


        }
    }

}