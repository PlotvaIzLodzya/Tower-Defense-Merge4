using System.Collections.Generic;
using _Source.Scripts.AttackBehaviours;
using _Source.Scripts.Helpers;
using _Source.Scripts.Projectiles;
using UnityEngine;

namespace _Source.Scripts.Upgrades
{
    [CreateAssetMenu(fileName = nameof(UpgradeList), menuName = NamingConstant.Upgrades + "/" + nameof(UpgradeList))]
    public class UpgradeList : ScriptableObject
    {
        [SerializeField] private AttackBehaviour[] _attackBehaviours;
        [SerializeField] private ProjectileMovement[]  _projectileMovements;
        [SerializeField] private OnHitBehaviour[] _onHitBehaviours;
        [SerializeField] private OnMovementEnd[]  _onMovementEnds;
        [SerializeField] private OnStayOnEnemy[]  _onStayOnEnemies;
        
#if UNITY_EDITOR
        [ContextMenu(nameof(Populate))]
        private void Populate()
        {
            _attackBehaviours = FindAllScriptableAssets<AttackBehaviour>();
            _projectileMovements  = FindAllScriptableAssets<ProjectileMovement>();
            _onHitBehaviours = FindAllScriptableAssets<OnHitBehaviour>();
            _onMovementEnds = FindAllScriptableAssets<OnMovementEnd>();
            _onStayOnEnemies = FindAllScriptableAssets<OnStayOnEnemy>();
            UnityEditor.EditorUtility.SetDirty(this);
        }
        
        private T[] FindAllScriptableAssets<T>() where T : ScriptableObject
        {
            var results = new List<T>();
            var guids = UnityEditor.AssetDatabase.FindAssets("t:ScriptableObject");
        
            foreach (string guid in guids)
            {
                var path = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                ScriptableObject asset = UnityEditor.AssetDatabase.LoadAssetAtPath<ScriptableObject>(path);
            
                if (asset is T typedAsset)
                    results.Add(typedAsset);
            }
        
            return results.ToArray();
        }
    }
#endif
}
