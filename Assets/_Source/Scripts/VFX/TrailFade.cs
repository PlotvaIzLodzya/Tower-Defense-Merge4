using System.Collections;
using UnityEngine;

namespace _Source.Scripts.VFX
{
    public class TrailFade : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trail;
        [SerializeField] private AnimationCurve _fadeCurve;

        private void Awake()
        {
            StartCoroutine(Fading(0.75f));
        }

        private IEnumerator Fading(float fadeTime)
        {
            var elapesedTime = 0f;
            var color = _trail.material.color;
            var startAlpha = color.a;
            while (elapesedTime < fadeTime) 
            {
                elapesedTime += Time.deltaTime;
                var alpha = startAlpha * _fadeCurve.Evaluate(elapesedTime/fadeTime);
                color.a = alpha;
                _trail.material.color = color;

                yield return null;
            }
        }
    }
}
