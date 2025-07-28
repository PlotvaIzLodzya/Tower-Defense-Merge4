using System;

namespace _Source.Scripts.Buildings
{
    [Serializable]
    public struct BuildingStats
    {
        public int Level;

        public void Add(BuildingStats stats)
        {
            Level += stats.Level;
        }
    }
}