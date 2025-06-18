using System;
using System.Runtime;
using System.Runtime.ExceptionServices;

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
                // Creates and adds each unique platform individually to the list platforms 
                Platform uniquePlatform = new Platform($"Platform-{i}");
                platforms.Add(uniquePlatform);

                // Shows by console that the platforms are created
                Console.WriteLine($"Created Platform: {uniquePlatform.id}");
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
            Console.WriteLine(" "); // Blank space for clarity
            Console.WriteLine("Please select your option ");

            int selection = int.Parse(Console.ReadLine());

            if (selection == 1)
            {
                // Attemps to load the trains from a specific file 
                Console.WriteLine("You have selected to load the trains from files option");
                LoadTrainsFromFile();
            }
            else if (selection == 2)
            {
                Console.WriteLine("You have selected to load the trains manually.");
            }
            else if (selection == 3)
            {
                Console.WriteLine("You have selected to start the simulation.");


            }
            else if (selection == 4)
            {
                Console.WriteLine("The program will exit.");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
                PrintMenu();
            }


        }

        public void LoadTrainsFromFile()
        {
            // The user must enter the file path
            Console.WriteLine("Please enter the path of the file you wish to load: ");

            string path = Console.ReadLine();

            using (StreamReader sr = new StreamReader(path))
            {
                string line;

                string separator = ",";

                sr.ReadLine(); // Skips the header

                // Reads the file per file until it is blank
                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split(separator);


                    // We assign the data 
                    string id = fields[0];

                    // Checks no duplicate ID's for each train 
                    CheckID(id); 


                    int arrivalTime = Int32.Parse(fields[1]);
                    string type = fields[2];

                    if (type == "Passenger")
                    {
                        int numberOfCarriages = int.Parse(fields[3]);
                        int capacity = Int32.Parse(fields[4]);
                        trains.Add(new PassengerTrain(id, arrivalTime, type, numberOfCarriages, capacity));


                    }
                    else if (type == "Freight")
                    {
                        int maxWeight = int.Parse(fields[3]);
                        string freightType = fields[4];
                        trains.Add(new FreightTrain(id, arrivalTime, type, maxWeight, freightType));
                    }

                }

                // As per the statement, a file with a minimum of 15 trains should be loaded
                if (trains.Count < 15)
                {
                    trains.Clear();
                    Console.WriteLine("You must give a file with 15 trains minimum");
                    PrintMenu(); // Returns the user to the menu
                }


                DisplayStatus(); 

            }



        }

        public void CheckID(string id)
        {
            foreach (var train in trains)
            {
                // If the ID is repeated a message is shown
                if (id == train.id)
                {
                    Console.WriteLine($"Train {id} already exists");
                    PrintMenu(); // User is returned to the menu. 
                }
            }
            
        } 

        public void DisplayStatus()
        {
            Console.WriteLine("\n=============== PLATFORMS STATUS ================");
            foreach (var platform in platforms)
            {
                Console.WriteLine("Here the platforms' status will be printed");
            }

            Console.WriteLine("\n=============== TRAINS STATUS ===================");
            foreach (var train in trains)
            {
                train.ShowTrainInfo();
            }
            Console.WriteLine("=================================================\n");
        }
    }

}