using System;

namespace OOP
{

    public class FreightTrain : Train
    {
        private int maxWeight;
        private string freightType; 

        public FreightTrain(string id, int arrivalTime, string type, int maxWeight, string freightType)
        : base(id, arrivalTime, type)
        {
            this.maxWeight = maxWeight;
            this.freightType = freightType;
        }

        public int GetMaxWeight()
        {
            return this.maxWeight; 
        }

        public string GetFreightType()
        {
            return this.freightType; 
        }

        // Shows the info of the base class + its own attributes from the subclass freight 
        public override void ShowTrainInfo()
        {
            base.ShowTrainInfo();
            Console.WriteLine($" | Max Weight: {maxWeight} | Freight Type: {freightType}");
        }
    }


}