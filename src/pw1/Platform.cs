using System;

namespace OOP
{

    public class Platform
    {
        public string id { get; set; }
        public PlatformStatus platformStatus { get; set; }
        public Train currentTrain { get; set; }
        public int dockingTimeRemaining { get; set; }
        public int dockingDuration = 2; // in ticks
        public enum PlatformStatus
        {
            Free,
            Occupied
        }

        public Platform(string id)
        {
            this.id = id;
            platformStatus = PlatformStatus.Free;
            this.currentTrain = null;
            this.dockingTimeRemaining = 2; // Time for docking requiered
        }

        public string GetStatus()
        {
            // If a platform is free 
            if (platformStatus == PlatformStatus.Free)
            {
                return $"{id} IS FREE";
            }
            // If a platform is not free 
            else
            {
                return $"{id} is ocupied by Train {currentTrain.id}, with {dockingTimeRemaining} ticks to dock";
            }
        }

        public void RequestPlatform(Train train)
        {
            if (platformStatus == PlatformStatus.Free)
            {
                platformStatus = PlatformStatus.Occupied; // The platform is being used by a train
                currentTrain = train; // We assign a train to a specific platform
                dockingTimeRemaining = 2; // We reset the ticks remaning to dock
                Console.WriteLine($"Train: {train.id} is docking on {id}");
                train.trainStatus = Train.TrainStatus.Docking; // We change the status of the train to docking
            }
            else
            {
                Console.WriteLine($"{id} is not free at the moment"); // We tell the user that the platform is not free
            }
        }

        public void UpdateTick()
        {
            if (platformStatus == PlatformStatus.Occupied && currentTrain != null)
            {
                dockingTimeRemaining--; // We substract a tick

                GetStatus();

                if (dockingDuration <= 0)
                {
                    currentTrain.trainStatus = Train.TrainStatus.Docked;
                    Console.WriteLine($"Train {id} has docked in {id}"); 
                }
            }
        }
    }



}