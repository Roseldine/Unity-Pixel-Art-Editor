
using UnityEngine;

namespace PixelEditor
{
    /// <summary>
    /// Color changed
    /// </summary>
    [System.Serializable]
    public class EAColorChange : EditorAction
    {
        [SerializeField] Color[] colors;

        public Color NewColor => colors[0];
        public Color OldColor => colors[1];

        public EAColorChange(Color oldColor, Color newColor)
        {
            colors = new Color[2];

            colors[0] = newColor;
            colors[1] = oldColor;

            string oldColorString = oldColor.ToString();
            string newColorString = newColor.ToString();

            description = "Color changed from: " + oldColorString + ", to: " + newColorString;
        }
    }
}