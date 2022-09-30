using System.Collections;
using UnityEngine;
using StardropTools;

namespace PixelEditor
{
    /// <summary>
    /// Paint Tool used for free pixel placement
    /// </summary>
    public class PaintToolBrush : PaintTool
    {
        public override void Initialize()
        {
            base.Initialize();

        }

        // No input validated on parent class, so feel free to just add input logic
        public override void Tick()
        {
            base.Tick();

            if (InputManager.HasInput == false || LegacyInputManager.Instance.IsOverUI)
                return;

            PaintToolManager.Instance.SpawnPixel(InputManager.CalmpedInputPosition);
        }
    }
}