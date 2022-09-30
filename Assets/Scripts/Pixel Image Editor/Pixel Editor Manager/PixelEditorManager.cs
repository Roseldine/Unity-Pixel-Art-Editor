
using UnityEngine;
using StardropTools;

namespace PixelEditor
{
    // The class that starts the whole program
    public class PixelEditorManager : MonoBehaviour
    {
        private void Awake()
        {
            // Inialize static methods
            EditorActionList.Initialize();

            // Get Managers, Initialize & LateInitialize them
            IManager[] managers = Utilities.GetItems<IManager>(transform).ToArray();

            // Initialize
            for (int i = 0; i < managers.Length; i++)
                managers[i].InitializeManager();

            // LateInitialize
            for (int i = 0; i < managers.Length; i++)
                managers[i].LateInitializeManager();


            PixelEditorEvents.OnInitialized?.Invoke();
        }
    }
}