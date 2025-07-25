using System;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace OOP
{

    public class Platform
    {
        private string id { get; set; }
        private PlatformStatus platformStatus { get; set; }
        private Train currentTrain { get; set; }
        private int dockingTime { get; set; }

        private enum PlatformStatus
        {
            Free,
            Occupied
        }

        public Platform(string id)
        {
            this.id = id;
            platformStatus = PlatformStatus.Free; // By default all platforms are free when instantiated 
            this.currentTrain = null;
            this.dockingTime = 3; // Time for docking required, it is 3 given that the first iteration already takes away a tick
        }

        // Shows to the user the amount of platforms created and their names
        public void ShowCreatedPlatforms(int i)
        {
            Console.WriteLine($"Created {id}");  // Shows the platforms created 
        }

        public string GetStatus()
        {
            // If a platform is free 
            if (platformStatus == PlatformStatus.Free)
            {
                return $"{id} IS FREE"; // Shows the platform is free 
            }
            // If a platform is not free 
            else
            {
                // If the docking time is equal to 2
                if (dockingTime == 2)
                {
                    return $"{id} is occupied by Train: {currentTrain.GetID()}, with {dockingTime} ticks remaining to dock.";
                }
                // If the docking time is 1 
                else if (dockingTime == 1)
                {
                    return $"{id} is occupied by Train: {currentTrain.GetID()}, with {dockingTime} tick remaining to dock ";
                }
                // Otherwise
                else
                {
                    return $"{id} is occupied by Train {currentTrain.GetID()}.";
                }
            }
        }

        // Train is requesting a platform to start the process of docking 
        public bool RequestPlatform(Train train)
        {
            // If a platform is free 
            if (platformStatus == PlatformStatus.Free)
            {
                platformStatus = PlatformStatus.Occupied; // The platform is being used by a train
                currentTrain = train; // We assign a train to a specific platform
                dockingTime = 3; // We reset the ticks remaining to dock
                Console.WriteLine($"Train: {currentTrain.GetID()} is docking on {id}");
                train.SetTrainStatus(Train.TrainStatus.Docking); // We change the status of the train to docking
                return true;
            }

            // If platform is not free then 
            return false;
        }

        public void UpdateTick()
        {
            if (platformStatus == PlatformStatus.Occupied && currentTrain != null)
            {
                dockingTime--; // We subtract a tick 

                if (dockingTime <= 0)
                {
                    dockingTime = 0; // To avoid negative values 
                    currentTrain.SetTrainStatus(Train.TrainStatus.Docked); // We change the status of the train to docked
                    platformStatus = PlatformStatus.Free; // We free the platform
                    // Shows the user that a train has docked, and has left the platform free 
                    Console.WriteLine($"Train {currentTrain.GetID()} with {dockingTime} ticks remaining, has docked, leaving {id} free");
                    Console.WriteLine(" "); // Black space for clarity 
                }
            }
        }
    }
}