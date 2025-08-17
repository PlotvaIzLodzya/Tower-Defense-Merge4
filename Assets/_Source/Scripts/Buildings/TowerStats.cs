using System;

namespace _Source.Scripts.Buildings
{
    
    [Serializable]
    public class TowerStats
    {
        public int Level;
        public float AttackRadius => 25f;
        public int Damage => Level * 10;
        public float AttackSpeed => Level * 100;

        public TowerStats()
        {

        }

        public TowerStats(TowerStats stats)
        {
            Upgrade(stats);
        }

        public void Upgrade(TowerStats stats)
        {
            Level += stats.Level;
        }

        public void SetValues(TowerStats stats)
        {
            Level = stats.Level;
        }
    }
}