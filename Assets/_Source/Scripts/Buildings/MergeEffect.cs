using System.Collections;
using System.Collections.Generic;
using _Source.Scripts.GameFeatures;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class MergeEffect : MonoBehaviour
    {
        [SerializeField] private GamePause _gamePause;
        
        public void Play(List<MergeData> mergeData)
        {
            StartCoroutine(MergingTowers(mergeData));
        }

        private IEnumerator MergingTowers(List<MergeData> mergeData)
        {
            foreach (var data in mergeData)
            {
                _gamePause.Pause();
                var cellsToMerge = data.CellsToMerge;
                var cellMergeTo = cellsToMerge[0];
                yield return MergingTower(cellsToMerge);
                cellMergeTo.MarkToMerge(false);
                cellMergeTo.Tower.SetStats(data.Config);
                _gamePause.Resume();
                yield return new WaitForSeconds(0.1f);
            }
        }

        private IEnumerator MergingTower(List<BuildingCell> cellsToMerge)
        {
            var cellMergeTo = cellsToMerge[0];
            Coroutine mergingCoroutine = null;
            for (int i = 1; i < cellsToMerge.Count; i++)
            {
                mergingCoroutine = StartCoroutine(PlayingEffect(cellsToMerge[i].Tower, cellMergeTo.Tower));
            }

            yield return mergingCoroutine;
            
            for (int i = 1; i < cellsToMerge.Count; i++)
            {
                cellsToMerge[i].DestroyBuilding();
                cellsToMerge[i].MarkToMerge(false);
            }
        }
        
        private IEnumerator PlayingEffect(Tower mergedTower, Tower targetTower)
        {
            var time = 0.3f;
            var elapsedTime = 0f;
            var startPosition = mergedTower.transform.position;
            while (elapsedTime < time)
            {
                mergedTower.transform.position = Vector3.Lerp(startPosition, targetTower.transform.position, elapsedTime / time);
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }
        }
    }
}