using System.Collections.Generic;
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
