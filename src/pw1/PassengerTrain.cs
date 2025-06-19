using System;

namespace OOP
{

    public class PassengerTrain : Train
    {
        private int numberOfCarriages;
        private int capacity; 

        public PassengerTrain(string id, int arrivalTime, string type, int numberOfCarriages, int capacity)
            : base(id, arrivalTime, type)
        {
            this.numberOfCarriages = numberOfCarriages;
            this.capacity = capacity;
        }

        public int GetNumberCarriages()
        {
            return this.numberOfCarriages; 
        }

        public int GetCapacity()
        {
            return this.capacity; 
        }
        
        // Shows the info of the base class + its own attributes from the subclass passenger

        public override void ShowTrainInfo()
        {
            base.ShowTrainInfo();
            Console.WriteLine($" | Number of Carriages: {numberOfCarriages} | Capacity: {capacity}");
        }
    }


}