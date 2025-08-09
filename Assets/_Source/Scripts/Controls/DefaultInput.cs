using UnityEngine;

namespace _Source.Scripts.Controls
{
    public interface IInput
    {
        bool PointerUp { get; }
        bool PointerDown { get; }
        bool PointerHeld { get; }
        
        Vector3 PointerPosition { get;}
    }
    
    public class DefaultInput : MonoBehaviour, IInput
    {
        public bool PointerUp { get; private set; }
        public bool PointerDown { get; private set; }
        public bool PointerHeld { get; private set; }
        
        public Vector3 PointerPosition { get; private set; }

        private void Update()
        {
            PointerUp = Input.GetMouseButtonUp(0);
            PointerDown = Input.GetMouseButtonDown(0);
            PointerHeld = Input.GetMouseButton(0);
            
            PointerPosition = Input.mousePosition;
        }
    }
}
