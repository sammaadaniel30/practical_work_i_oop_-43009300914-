using System;

namespace OOP
{

    public abstract class Train
    {
        public string id { get; set; }
        public TrainStatus trainStatus { get; set; }
        public int arrivalTime { get; set; }
        public string type { get; set; }

        public enum TrainStatus
        {
            EnRoute, Waiting, Docking, Docked
        }

        public Train(string id, int arrivalTime, string type)
        {
            this.id = id;
            this.arrivalTime = arrivalTime;
            this.type = type;
            trainStatus = TrainStatus.EnRoute; // By default trains loaded will be EnRoute
        }

        public virtual void ShowTrainInfo()
        {
            Console.Write($"ID: {id} | Arrival Time: {arrivalTime} | Type: {type} km | Status: {trainStatus}");
        }
    }


}


