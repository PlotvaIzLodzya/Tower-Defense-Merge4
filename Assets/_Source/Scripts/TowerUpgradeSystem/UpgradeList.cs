using System.Collections.Generic;
using System.Linq;
using _Source.Scripts.Helpers;
using _Source.Scripts.Projectiles;
using UnityEditor;
using UnityEngine;

namespace _Source.Scripts.TowerUpgradeSystem
{
    [CreateAssetMenu(fileName = nameof(UpgradeList), menuName = NamingConstant.Upgrades + "/" + nameof(UpgradeList))]
    public class UpgradeList : ScriptableObject
    {
        [SerializeField] private BehaviourUpgrade[] _upgrades;

        public List<BehaviourUpgrade> GetBehaviourUpgrades(Tags tags, int amount)
        {
            var upgradeList = new List<BehaviourUpgrade>(amount);
            var appropriateUpgrades = _upgrades.Where(b => b.Tags.HasFlag(tags)).ToList();
            for (int i = 0; i < amount; i++)
            {
                var randomIndex = Random.Range(0, amount);
                var upgrade = appropriateUpgrades[randomIndex];
                upgradeList.Add(upgrade);
                appropriateUpgrades.RemoveAt(randomIndex);
            }
            
            return upgradeList;
        }
        
#if UNITY_EDITOR
        [ContextMenu(nameof(Populate))]
        private void Populate()
        {
            _upgrades = FindAllScriptableAssets<BehaviourUpgrade>();
            EditorUtility.SetDirty(this);
        }
        
        private T[] FindAllScriptableAssets<T>() where T : ScriptableObject
        {
            var results = new List<T>();
            var guids = AssetDatabase.FindAssets("t:ScriptableObject");
        
            foreach (string guid in guids)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                ScriptableObject asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
            
                if (asset is T typedAsset)
                    results.Add(typedAsset);
            }
        
            return results.ToArray();
        }
    }
#endif
}
