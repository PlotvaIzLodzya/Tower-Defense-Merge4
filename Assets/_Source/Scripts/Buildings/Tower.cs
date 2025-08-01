using TMPro;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class TowerConfig : ScriptableObject
    {
        public TowerStats TowerStats;
    }
    
    public class Tower : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private TowerConfig _config;
        
        public Vector3Int GridPosition => transform.position.ToGrid();
        public TowerStats Stats { get; private set; }

        private void Awake()
        {
            Stats = new TowerStats()
            {
                Level = 1
            };
        }

        public void OnBuild()
        {
            transform.localPosition = Vector3.zero;
        }

        public void Merge(TowerStats stats)
        {
            Stats = stats;
            _lvl.text = $"{Stats.Level}";
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}