using System;

namespace OOP
{ 

    public class PassengerTrain : Train
    {
        public int numberOfCarriages { get; set; }
        public int capacity { get; set; }

        public PassengerTrain(string id, int arrivalTime, string type, int numberOfCarriages, int capacity)
            : base(id, arrivalTime, type)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }
    }


}