using System;
using UnityEditor;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    [Serializable]
    public class TowerBlueprint
    {
        public Vector3Int Offset;
        public TowerStats Stats;
    }
    
    public class TowerBlockPreset : MonoBehaviour
    {
        [SerializeField] private Tower[] _towers;
        
        public TowerBlueprint[] Blueprints;
        
        [ContextMenu("Setup form")]
        public void UpdateForm()
        {
            var towers = GetComponentsInChildren<Tower>();
            _towers = towers;
            Blueprints = new TowerBlueprint[towers.Length];
            for (int i = 0; i < towers.Length; i++)
            {
                var tower = towers[i];
                Blueprints[i] = new TowerBlueprint()
                {
                    Stats = tower.Stats,
                    Offset = tower.transform.localPosition.ToGrid(),
                };
            }
#if UNITY_EDITOR
            EditorUtility.SetDirty(gameObject);
#endif
        }
        
        public void UpdateTowersView()
        {
            for (int i = 0; i < _towers.Length; i++)
            {
                _towers[i].SetStats(Blueprints[i].Stats);
                
            }
        }

        public int GetPrice()
        {
            var price = 0;
            
            foreach (var blueprint in Blueprints)
                price += blueprint.Stats.Level * GameConfig.PricePerTowerLvl;
            
            return price;
        }
    }
}