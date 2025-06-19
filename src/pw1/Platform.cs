using System;

namespace OOP
{

    public class Platform
    {
        public string id { get; set; }
        public PlatformStatus platformStatus { get; set; }
        public Train currentTrain { get; set; }
        public int dockingTime { get; set; }
        public enum PlatformStatus
        {
            Free,
            Occupied
        }

        public Platform(string id)
        {
            this.id = id;
            platformStatus = PlatformStatus.Free; // By default all platforms are free when instantiated 
            this.currentTrain = null;
            this.dockingTime = 2; // Time for docking requiered
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
                if (dockingTime > 0)
                {
                    return $"{id} is ocupied by Train {currentTrain.id}, with {dockingTime} ticks to dock";
                }
                else
                {
                    return $"{id} is ocupied by Train {currentTrain.id}";
                }
            }
        }

        public void RequestPlatform(Train train)
        {
            if (platformStatus == PlatformStatus.Free)
            {
                platformStatus = PlatformStatus.Occupied; // The platform is being used by a train
                currentTrain = train; // We assign a train to a specific platform
                dockingTime = 2; // We reset the ticks remaning to dock
                Console.WriteLine($"Train: {currentTrain.id} is docking on {id}");
                train.trainStatus = Train.TrainStatus.Docking; // We change the status of the train to docking
            }
        }

        public void UpdateTick()
        {
            if (platformStatus == PlatformStatus.Occupied && currentTrain != null)
            {
                dockingTime--; // We substract a tick

                GetStatus();

                if (dockingTime <= 0)
                {
                    dockingTime = 0; 
                    currentTrain.trainStatus = Train.TrainStatus.Docked;
                    Console.WriteLine($"Train {currentTrain.id} has docked in {id}"); 
                }
            }
        }
    }



}