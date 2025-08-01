using System;

namespace _Source.Scripts.Buildings
{
    [Serializable]
    public struct TowerStats
    {
        public int Level;

        public void Add(TowerStats stats)
        {
            Level += stats.Level;
        }
    }
}