using System;

namespace OOP
{
    public class Station
    {
        public List<Platform> platforms { get; set; }
        public List<Train> trains { get; set; }

        public double ticksPerHour = 0.25;  
        
        public Station(int numberOfPlatforms)
        {
            platforms = new List<Platform>();
            trains = new List<Train>();

            for (int i = 1; i <= numberOfPlatforms; i++)
            {
                platforms.Add(new Platform($"Platform-{i}"));
            }
        }
    }
}