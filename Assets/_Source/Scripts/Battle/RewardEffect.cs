using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class RewardEffect : MonoBehaviour
    {
        [SerializeField] private float _playTime;
        [SerializeField] private float _height;
        [SerializeField] private TMP_Text _reward;
        
        public void Play(Vector3 position, int reward)
        {
            position.y += 1f;
            transform.position = position;
            _reward.text = $"{reward}";
            var endHeight = position.z + _height;
            _reward.DOFade(0, _playTime).SetEase(Ease.OutQuad);
            transform.DOMoveZ(endHeight, _playTime).SetEase(Ease.OutQuad).OnComplete(()=>Destroy(gameObject));
        }
    }
}