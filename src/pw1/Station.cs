using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace OOP
{
    public class Station
    {
        private List<Platform> platforms { get; set; }
        private List<Train> trains { get; set; }

        private int minutesPerTick = 15; // Each tick represents 15 minutes

        public Station(int numberOfPlatforms)
        {
            platforms = new List<Platform>();
            trains = new List<Train>();

            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                // Creates and adds each unique platform individually to the list platforms 
                Platform uniquePlatform = new Platform($"Platform-{i}");
                platforms.Add(uniquePlatform);
                uniquePlatform.ShowCreatedPlatforms(i); 

                

                
            }
        }

        public void PrintMenu()
        {
            Console.WriteLine("___________________________________");
            Console.WriteLine("|+++++++++++ Train UFV +++++++++++|");
            Console.WriteLine("|---------------------------------|");
            Console.WriteLine("| Choose an option                |");
            Console.WriteLine("| 1. Load trains from file        |");
            Console.WriteLine("| 2. Start simulation             |");
            Console.WriteLine("| 3. Exit                         |");
            Console.WriteLine("|---------------------------------|");
            Console.WriteLine("|+++++++++++++++++++++++++++++++++|");
            Console.WriteLine("|---------------------------------|");

            SelectOption();

        }

        public void SelectOption()
        {
            try
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
                    Console.WriteLine("You have selected to start the simulation.");
                    StartSimulation();
                }
                else if (selection == 3)
                {
                    Console.WriteLine("The program will exit.");
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    PrintMenu();
                }
            }
            catch (ArgumentNullException ex2)
            {
                Console.WriteLine($"An error has been detected: {ex2.Message}");
                Console.WriteLine("Please try again, input can't be null");
                PrintMenu();
            }
            catch (FormatException ex3)
            {
                Console.WriteLine($"An error has been detected: {ex3.Message}");
                Console.WriteLine("Please try again, input must be a number");
                PrintMenu(); 
            }



        }

        public void StartSimulation()
        {
            AdvanceTick();
        }

        public void LoadTrainsFromFile()
        {
            try
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
                    PrintMenu();

                }
            }
            catch (FileNotFoundException ex4)
            {
                Console.WriteLine($"An error has been detected: {ex4.Message}");
                Console.WriteLine("Please introduce the path of a file which exists");
                LoadTrainsFromFile();
            }
            catch (ArgumentNullException ex5)
            {
                Console.WriteLine($"An error has been detected: {ex5.Message}");
                Console.WriteLine("The inputted path can't be blank. Please try again");
                LoadTrainsFromFile(); 
            }



        }

        public void CheckID(string id)
        {
            foreach (var train in trains)
            {
                // If the ID is repeated a message is shown
                if (id == train.GetID())
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
                Console.WriteLine(platform.GetStatus());
            }

            Console.WriteLine("\n=============== TRAINS STATUS ===================");
            foreach (var train in trains)
            {
                train.ShowTrainInfo();
            }
            Console.WriteLine("=================================================\n");
        }

        public void AdvanceTick()
        {
            foreach (var train in trains)
            {
                if (train.GetTrainStatus() == Train.TrainStatus.EnRoute)
                {

                    int arrivalTime = train.GetArrivalTime() - minutesPerTick;
                    train.SetArrivalTime(arrivalTime); 

                    if (train.GetArrivalTime() <= 0)
                    {
                        train.SetArrivalTime(0); // We avoid negative values 
                        Console.WriteLine($"Train {train.GetID()} has reached the station");
                        AttempRequestPlatfrom(train);
                    }

                }

                else if (train.GetTrainStatus() == Train.TrainStatus.Waiting)
                {
                    AttempRequestPlatfrom(train);
                }
            }

            foreach (var platform in platforms)
            {
                platform.UpdateTick();
            }

            DisplayStatus(); // Shows the station info

            CheckDockedTrains(); 

            // Asks the user if he wants another tick or go back to the menu
            Console.WriteLine("Press any key to do another tick simulation, or type Menu to return to the main menu");

            string input = Console.ReadLine();

            if (input.ToLower() == "menu")
            {
                PrintMenu();
            }
            else
            {
                StartSimulation();
            }
        }

        public void AttempRequestPlatfrom(Train train)
        {
            bool platformAssigned = false; // Indication wether the train is assigned to a platform 

            foreach (var platform in platforms)
            {
                if (!platformAssigned)
                {
                    platformAssigned = platform.RequestPlatform(train); // We request a platform for the train
                    
                }
            }
        }

        public void CheckDockedTrains()
        {
            int countDockedTrains = 0;
            foreach (var train in trains)
            {
                if (train.GetTrainStatus() == Train.TrainStatus.Docked)
                {
                    countDockedTrains++;
                }
            }

            if (countDockedTrains == trains.Count)
            {
                Console.WriteLine("All trains have been docked");
                Console.WriteLine("The program will now finish");
                Environment.Exit(0); 
            }
        }

    }
}