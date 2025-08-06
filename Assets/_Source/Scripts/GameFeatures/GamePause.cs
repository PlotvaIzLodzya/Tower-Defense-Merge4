using UnityEngine;

namespace _Source.Scripts.GameFeatures
{
    public class GamePause : MonoBehaviour
    {
        public void Pause()
        {
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            Time.timeScale = 1f;
        }
    }
}
