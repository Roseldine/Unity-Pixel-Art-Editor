using System.Collections;
using UnityEngine;
using StardropTools;

namespace PixelEditor
{
    public abstract class PaintTool : BaseComponent
    {
        [SerializeField] protected bool isActive;

        public bool IsActive => isActive;

        /// <summary>
        /// Activate or Deactivate the paint tool
        /// <para> value True = active, value False = deactive </para>
        /// </summary>
        public virtual void ActivateTool(bool value)
        {
            if (value == isActive)
                return;

            if (value == true)
                StartTick();
            else
                StopTick();

            isActive = value;
        }

        public override void Tick()
        {
            base.Tick();

            if (InputManager.HasInput == false)
                return;
        }
    }
}