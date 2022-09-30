
using UnityEngine;
using UnityEngine.UI;
using StardropTools;
using StardropTools.UI;

namespace PixelEditor
{
    [RequireComponent(typeof(UIToggleButton))]
    public class UIButtonTool : BaseComponent
    {
        [Header("Paint Tool")]
        [SerializeField] PaintToolType toolType;
        [SerializeField] UIToggleButton toggleButton;
        [SerializeField] float pixelsPerUnit = 32;
        [SerializeField] Image[] images;

        public UIToggleButton ToggleButton => toggleButton;
        public PaintToolType ToolType => toolType;

        public override void Initialize()
        {
            base.Initialize();

            toggleButton.OnClick.AddListener(() => PixelEditorEvents.OnPaintToolSelected?.Invoke(toolType));
        }

        public void Toggle() => toggleButton.Toggle();

        public void Toggle(bool toggle) => toggleButton.Toggle(toggle);


        protected void OnValidate()
        {
            if (toggleButton == null)
                toggleButton = GetComponent<UIToggleButton>();

            UtilitiesUI.SetImagesPixelsPerUnitMultiplier(images, pixelsPerUnit);
        }
    }
}