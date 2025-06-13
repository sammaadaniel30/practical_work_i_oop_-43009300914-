using System;

namespace OOP
{ 

    public abstract class Train
    {
        public string id { get; set; }
        public TrainStatus status { get; set; }
        public int arrivalTime { get; set; } 
        public string type { get; set; }

        public enum TrainStatus
        {
            EnRoute, Waiting, Docking, Docked
        }

        public Train(string id, int arrivalTime, string type)
        {
            this.id = id;
            this.arrivalTime  = arrivalTime;
            this.type = type;
            status = TrainStatus.EnRoute; // By default trains loaded will be EnRoute
        }
    }


}


