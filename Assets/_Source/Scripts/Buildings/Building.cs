using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class BuildingConfig : ScriptableObject
    {
        public BuildingStats BuildingStats;
    }


    
    public class Building : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lvl;
        [SerializeField] private BuildingConfig _config;
        
        public Vector3Int GridPosition => transform.position.ToGrid();
        public BuildingStats Stats { get; private set; }

        private void Awake()
        {
            Stats = new BuildingStats()
            {
                Level = 1
            };
        }

        public void OnBuild()
        {
            transform.localPosition = Vector3.zero;
        }

        public void Merge(BuildingStats stats)
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