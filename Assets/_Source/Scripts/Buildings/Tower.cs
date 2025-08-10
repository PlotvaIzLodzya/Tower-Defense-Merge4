using System.Collections;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class TowerConfig : ScriptableObject
    {
        public TowerStats TowerStats;
    }

    public abstract class Tower : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lvl;
        
        [field: SerializeField] public TowerStats Stats { get; private set; }
        // [SerializeField] private TowerConfig _config;
        
        public Vector3Int GridPosition => transform.position.ToGrid();

        public void OnBuild()
        {
            transform.localPosition = Vector3.zero;
        }

        public void SetStats(TowerStats stats)
        {
            Stats.SetValues(stats);
            _lvl.text = $"{Stats.Level}";
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }


    }
}