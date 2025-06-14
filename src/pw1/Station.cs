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

        public void LoadFromFile()
        {
            // The user must enter the file path
            Console.WriteLine("Please enter the path of the file you wish to load: ");

            string path = Console.ReadLine();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                string separator = ",";

                // Reads the file per file until it is blank
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split(separator);

                    // We assign the data 
                    string id = fields[0];
                    int arrivalTime = int.Parse(fields[1]);
                    string type = fields[2];

                    if (type == "Passenger")
                    {
                        int numberOfCarriages = int.Parse(fields[3]);
                        int capacity = int.Parse(fields[4]);
                        trains.Add(new PassengerTrain(id, arrivalTime, type, numberOfCarriages, capacity));


                    }
                    else if (type == "Freight")
                    {
                        int maxWeight = int.Parse(fields[3]);
                        string freightType = fields[4];
                        trains.Add(new FreightTrain(id, arrivalTime, type, maxWeight, freightType));
                    }
                
                }
            } 



        }
    }

}