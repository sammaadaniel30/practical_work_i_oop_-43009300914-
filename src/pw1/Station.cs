using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Net.NetworkInformation;
using System.Runtime;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography;
using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;

namespace OOP
{
    public class Station
    {
        private List<Platform> platforms { get; set; }
        private List<Train> trains { get; set; }

        private int minutesPerTick = 15; // Each tick represents 15 minutes

        private bool allTrainsDocked = false; // Controls when all trains have been docked 

        public Station(int numberOfPlatforms)
        {
            platforms = new List<Platform>(); // Creation of the list of platforms
            trains = new List<Train>(); // Creation of the list of trains

            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                // Creates and adds each unique platform individually to the list platforms 
                Platform uniquePlatform = new Platform($"Platform-{i}");
                platforms.Add(uniquePlatform);

                // Shows to the user the created platforms
                uniquePlatform.ShowCreatedPlatforms(i);

            }
        }

        public void PrintMenu()
        {
            // Shows the possible options to the user
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





            SelectOption(); // Calls the Select Option method 

        }

        public void SelectOption()
        {

            try
            {
                Console.WriteLine(" "); // Blank space for clarity

                // Asks the user for the option he desires
                Console.WriteLine("Please select your option ");
                int selection = int.Parse(Console.ReadLine());

                // If the user wishes to load the trains from a file 
                if (selection == 1)
                {
                    // Attempts to load the trains from a specific file 
                    Console.WriteLine("You have selected to load the trains from files option");
                    // Calls the method which loads the files 
                    LoadTrainsFromFile();
                }
                // If the user wishes to start the simulation
                else if (selection == 2)
                {
                    Console.WriteLine("You have selected to start the simulation.");
                    // Calls for starting the simulaiton 
                    StartSimulation();
                }
                // If the user wishes to exit the program manually 
                else if (selection == 3)
                {
                    // The program will finish
                    Console.WriteLine("You have selected to exit the program.");
                    Console.WriteLine("The program has exited successfully.");
                }
                // If the users enters a non-existent option 
                else
                {
                    // The user is informed about the option which is unavailable
                    Console.WriteLine("Invalid option. Please try again.");
                    PrintMenu(); // User is shown again the options
                }
            }
            // If the input is null 
            catch (ArgumentNullException ex2)
            {
                // Tells the user about the error
                Console.WriteLine($"An error has been detected: {ex2.Message}");
                Console.WriteLine("Please try again, input can't be null");
                PrintMenu(); // User is shown again the options 
            }
            // If the input is not a number 
            catch (FormatException ex3)
            {
                // Tells the user about the error 
                Console.WriteLine($"An error has been detected: {ex3.Message}");
                Console.WriteLine("Please try again, input must be a number");
                PrintMenu(); // User is shown again the options 
            }
        }

        public void StartSimulation()
        {
            AdvanceTick(); // Start to manage the trains arriving at the station 
        }

        public void LoadTrainsFromFile()
        {
            try
            {
                // The user must enter the file path, and also shows the warning on how the program works
                Console.WriteLine("WARNING!: The program treats the file has a header.");
                Console.WriteLine("If your program does not have a header please add a blank line at the top of the file.");
                Console.WriteLine("Otherwise some trains may be not loaded");
                Console.WriteLine("Please enter the path of the file you wish to load: ");
                string path = Console.ReadLine();

                string separator = ",";
                bool hasHeader = false;

                // Checks if there is a header
                using (StreamReader checkHeader = new StreamReader(path))
                {
                    string firstLine = checkHeader.ReadLine();

                    string[] fields = firstLine.Split(separator); // Splits the first line into fields 

                    if (fields[0].Trim().ToLower() == "id") // If "id" is found in the first line
                    {
                        hasHeader = true; // We assign the bool for true
                    }
                    // We close the file 
                    checkHeader.Close();

                }



                // Instantation of a StreamReader to read the data from the file 
                using (StreamReader sr = new StreamReader(path))
                {

                    if (hasHeader) // A header has been found 
                    {
                        sr.ReadLine(); // Skips the header (first line)
                    }

                    string line;

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

                    // We close the file 
                    sr.Close();
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
            // Prints the status of the platforms 
            Console.WriteLine("\n=============== PLATFORMS STATUS ================");
            foreach (var platform in platforms)
            {
                Console.WriteLine(platform.GetStatus());
            }
            // Prints the status of all of the trains
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
                // If trains are EnRoute
                if (train.GetTrainStatus() == Train.TrainStatus.EnRoute)
                {
                    // We decrement the amount of arrivaltime by the value of each tick
                    int arrivalTime = train.GetArrivalTime() - minutesPerTick;
                    train.SetArrivalTime(arrivalTime);


                    // When arrival time is 0 or less 
                    if (train.GetArrivalTime() <= 0)
                    {
                        train.SetArrivalTime(0); // We avoid negative values 
                        Console.WriteLine($"Train {train.GetID()} has reached the station"); // Informs the user that the train has arrived
                        AttempRequestPlatfrom(train); // Attemps to request a platform to start the process of docking 
                    }

                }

                // If the train is waiting 
                else if (train.GetTrainStatus() == Train.TrainStatus.Waiting)
                {
                    // Attemps to request a platform to start the process of docking
                    AttempRequestPlatfrom(train);
                }
            }

            foreach (var platform in platforms)
            {
                platform.UpdateTick(); // We update the ticks for each train docking in their respective platform
            }

            DisplayStatus(); // Shows the station info

            CheckDockedTrains(); // Checks if all of the train from the file have been docked 

            // As long as not all the trains have been docked
            if (!allTrainsDocked)
            {

                // Asks the user if he wants another tick or go back to the menu
                Console.WriteLine("Press any key to do another tick simulation, or type Menu to return to the main menu");
                string input = Console.ReadLine();

                // If the user types menu (in any way) 
                if (input.ToLower() == "menu")
                {
                    PrintMenu(); // Returns the user to the menu 
                }
                else
                {
                    StartSimulation(); // Otherwise the simulation continues 
                }
            }
        }

        // Each train attemps to request a platform 
        public void AttempRequestPlatfrom(Train train)
        {
            bool assigned = false; // Indication wether the train is assigned to a platform 

            foreach (var platform in platforms)
            {
                if (!assigned) // If the train has not been assigned to a platform
                {
                    assigned = platform.RequestPlatform(train); // We request a platform for the train
                }
            }

            // If a train is still waiting to be assigned 
            if (!assigned && train.GetTrainStatus() == Train.TrainStatus.Waiting)
            {
                Console.WriteLine($"No platforms available. Train: {train.GetID()} is still waiting.");
            }
            // If train has attempted to request a platfrom for the first time
            if (!assigned && train.GetTrainStatus() == Train.TrainStatus.EnRoute)
            {
                train.SetTrainStatus(Train.TrainStatus.Waiting);
                Console.WriteLine($"No platforms available. Train: {train.GetID()} is now waiting.");
            }
        }

        public void CheckDockedTrains()
        {
            int countDockedTrains = 0; // Counter of each train docked 
            foreach (var train in trains)
            {
                // Counts the number of trains already docked 
                if (train.GetTrainStatus() == Train.TrainStatus.Docked)
                {
                    countDockedTrains++;
                }
            }

            // When the number of trains docked are the same as the ones in the list loaded from the file 
            if (countDockedTrains == trains.Count)
            {
                // The program finishes 
                Console.WriteLine($"All {countDockedTrains} trains have been docked successfully");
                Console.WriteLine("The program will now finish");
                allTrainsDocked = true; // When all trains have been docked 
            }
        }

    }
}