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
            this.dockingTimeRemaining = 0;
        }
    }



}