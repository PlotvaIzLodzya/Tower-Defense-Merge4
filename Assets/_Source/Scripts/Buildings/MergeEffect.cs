using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Scripts.GameFeatures;
using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class MergeEffect : MonoBehaviour
    {
        [SerializeField] private GamePause _gamePause;
        
        public Coroutine Play(MergeData mergeData, Action<MergeData> afterMerge)
        {
            return StartCoroutine(MergingTowers(mergeData,afterMerge));
        }

        private IEnumerator MergingTowers(MergeData mergeData, Action<MergeData> afterMerge)
        {
            _gamePause.Pause();

            yield return MergingTower(mergeData.CellsToMerge, mergeData.CellMergeTo);
            
            afterMerge(mergeData);
            _gamePause.Resume();
            
            yield return new WaitForSeconds(0.1f);

        }

        private IEnumerator MergingTower(List<BuildingCell> cellsToMerge, BuildingCell cellMergeTo)
        {
            Coroutine mergingCoroutine = null;
            for (int i = 0; i < cellsToMerge.Count; i++)
            {
                mergingCoroutine = StartCoroutine(PlayingEffect(cellsToMerge[i].Tower, cellMergeTo.Tower));
            }

            yield return mergingCoroutine;
            
            for (int i = 1; i < cellsToMerge.Count; i++)
            {
                cellsToMerge[i].DestroyBuilding();
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