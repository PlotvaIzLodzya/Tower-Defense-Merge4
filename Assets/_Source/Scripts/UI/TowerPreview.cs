using _Source.Scripts.Buildings;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.UI
{
    public class TowerPreview : Panel
    {
        [SerializeField] private TMP_Text _lvl;

        public void UpdateView(BuildingStats stats)
        {
            _lvl.text = $"{stats.Level}";
        }
    }
}