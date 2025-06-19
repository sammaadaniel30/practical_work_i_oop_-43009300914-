using System;

namespace OOP
{

    public abstract class Train
    {
        protected string id; 
        protected TrainStatus trainStatus; 
        protected int arrivalTime; 
        protected string type; 

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

        public string GetID()
        {
            return this.id; 
        }

        public int GetArrivalTime()
        {
            return this.arrivalTime; 
        }

        public void SetArrivalTime(int arrivalTime)
        {
            this.arrivalTime = arrivalTime; 
        }

        public string GetType()
        {
            return this.type;
        }

        public TrainStatus GetTrainStatus()
        {
            return this.trainStatus;
        }

        public void SetTrainStatus(TrainStatus trainStatus)
        {
            this.trainStatus = trainStatus;
        }


        
        // Shows the info of the train 
        public virtual void ShowTrainInfo()
        {
            Console.Write($"ID: {id} | Arrival Time: {arrivalTime} | Type: {type} km | Status: {trainStatus}");
        }
    }


}


