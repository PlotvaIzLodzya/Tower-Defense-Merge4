using System.Collections;
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
            StartCoroutine(Playing(position, reward));
        }

        private IEnumerator Playing(Vector3 position, int reward)
        {
            float elapsedTime = 0;

            position.y += 1f;
            transform.position = position;
            _reward.text = $"{reward}";
            var startPosition = transform.position;
            var endPosition = startPosition + Vector3.forward * _height;
            
            while (elapsedTime < _playTime)
            {
                elapsedTime += Time.deltaTime;
                transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / _playTime);
                _reward.alpha = Mathf.Lerp(1, 0, elapsedTime / _playTime);
                yield return null;
            }
            
            Destroy(gameObject);
        }
    }
}