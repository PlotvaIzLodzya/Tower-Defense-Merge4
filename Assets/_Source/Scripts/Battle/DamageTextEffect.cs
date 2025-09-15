using _Source.Scripts.Projectiles;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _Source.Scripts.Battle
{
    public class DamageTextEffect : MonoBehaviour
    {
        [SerializeField] private float _playTime;
        [SerializeField] private float _height;
        [SerializeField] private float _distance;
        [SerializeField] private TMP_Text _damageText;
        
        public void Play(Vector3 position, DamageDTO dto)
        {
            position.y += 1f;
            transform.position = position;
            _damageText.text = $"{dto.Damage}";
            var dir = (position - dto.Position).normalized;
            var xPos = Random.Range(position.x + _distance * 0.5f, position.x + dir.x * _distance);
            
            var endPos = new Vector3(xPos, position.y, position.z + _height);
            transform.DOMoveX(endPos.x, _playTime);
            transform.DOMoveZ(endPos.z, _playTime * 0.5f).SetEase(Ease.OutQuad).OnComplete(() =>
            {
                transform.DOMoveZ(position.z, _playTime * 0.5f).SetEase(Ease.InQuad).OnComplete(() =>
                {
                    Destroy(gameObject);
                });

            });
        }
    }
}