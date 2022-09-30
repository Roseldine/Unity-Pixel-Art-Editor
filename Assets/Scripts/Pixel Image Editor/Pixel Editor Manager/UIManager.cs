using System.Collections;
using UnityEngine;
using StardropTools;
using StardropTools.UI;

namespace PixelEditor
{
    public class UIManager : MonoBehaviour, IManager
    {
        [SerializeField] UIRootCanvas rootCanvas;

        [Tooltip("0-brush, 1-eraser, 2-line, 3-fill")]
        [SerializeField] UIButtonTool[] toolButtons;

        public void InitializeManager()
        {
            rootCanvas.Initialize();

            for (int i = 0; i < toolButtons.Length; i++)
            {
                toolButtons[i].ToggleButton.ButtonID = i;
                toolButtons[i].Initialize();
                toolButtons[i].ToggleButton.OnToggleID.AddListener(ToggleID);
            }

            ToggleID(0);
        }

        public void LateInitializeManager() { }

        public void ToggleID(int buttonID)
        {
            for (int i = 0; i < toolButtons.Length; i++)
                if (i != buttonID)
                    toolButtons[i].Toggle(false);

            toolButtons[buttonID].Toggle(false);
        }
    }
}