using System;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public struct BuildingConfig
    {
        public int Level;

        public void Add(BuildingConfig config)
        {
            Level += config.Level;
        }
    }

    public class Building : MonoBehaviour
    {
        [SerializeField] private TMP_Text _lvl;
        
        public readonly Vector3 [] Form = new Vector3[]
        {
            new Vector3( 0, 0, 0),
        };
        
        public BuildingConfig Config { get; private set; }

        private void Awake()
        {
            Config = new BuildingConfig()
            {
                Level = 1
            };
        }

        public void Merge(BuildingConfig config)
        {
            Config = config;
            _lvl.text = $"{Config.Level}";
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}