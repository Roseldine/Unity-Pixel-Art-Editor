using System.Collections;
using UnityEngine;

namespace PixelEditor
{
    public class InputManager : Singleton<InputManager>, StardropTools.IManager
    {
        [SerializeField] LayerMask raycastLayer;
        [SerializeField] new Camera camera;
        [SerializeField] 
        bool hasInput;

        public static Vector3 InputPosition { get; private set; }
        public static Vector3 CalmpedInputPosition => new Vector3(Mathf.RoundToInt(InputPosition.x), Mathf.RoundToInt(InputPosition.y), Mathf.RoundToInt(InputPosition.z));
        public static bool HasInput { get; private set; }


        public void InitializeManager()
        {
            if (camera == null)
                camera = Camera.main;

            LoopManager.OnUpdate.AddListener(Tick);
        }

        public void LateInitializeManager() { }


        void Tick()
        {
            hasInput = Input.GetMouseButton(0) ? true : false;
            HasInput = hasInput;

            if (hasInput)
            {
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, raycastLayer))
                {
                    InputPosition = hit.point;
                }
            }

            else
                InputPosition = Vector3.zero;
        }
    }
}