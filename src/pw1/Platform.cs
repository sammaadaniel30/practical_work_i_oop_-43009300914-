using System;

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
            this.dockingTime = 2; // Time for docking requiered
        }

        public void ShowCreatedPlatforms(int i)
        {
            Console.WriteLine($"Created {id}"); 
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
                    return $"{id} is ocupied by Train {currentTrain.GetID()}, with {dockingTime} ticks to dock.";
                }
                else
                {
                    return $"{id} is ocupied by Train {currentTrain.GetID()}.";
                }
            }
        }

        public bool RequestPlatform(Train train)
        {
            if (platformStatus == PlatformStatus.Free)
            {
                platformStatus = PlatformStatus.Occupied; // The platform is being used by a train
                currentTrain = train; // We assign a train to a specific platform
                dockingTime = 2; // We reset the ticks remaning to dock
                Console.WriteLine($"Train: {currentTrain.GetID()} is docking on {id}");
                train.SetTrainStatus(Train.TrainStatus.Docking); // We change the status of the train to docking
                return true;
            }
            if (platformStatus == PlatformStatus.Occupied)
            {
                Console.WriteLine($"No platforms are available. Train {train.GetID()} is now waiting");
                train.SetTrainStatus(Train.TrainStatus.Waiting); // We change the status of the train to waiting
                return false;
            }

            // If anything is nothing from above then return false as we don't assign anything
            return false; 
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
                    currentTrain.SetTrainStatus(Train.TrainStatus.Docked); // We change the status of the train to docked
                    platformStatus = PlatformStatus.Free;
                    Console.WriteLine($"Train {currentTrain.GetID()} has docked leaving {id} free"); 
                }
            }
        }
    }



}