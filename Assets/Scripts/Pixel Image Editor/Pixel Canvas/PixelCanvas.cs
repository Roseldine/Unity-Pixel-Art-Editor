
using UnityEngine;
using StardropTools;

namespace PixelEditor
{
    public class PixelCanvas : MonoBehaviour, IManager
    {
        public Vector2Int size = new Vector2Int(32, 32);
        public Color color = Color.white;
        
        [Header("Camera")]
        [SerializeField] new Camera camera;
        [SerializeField] Camera cameraTransform;
        
        [Header("Background")]
        [SerializeField] Transform background;
        [SerializeField] MeshRenderer backgroundMesh;

        public void InitializeManager()
        {
            
        }

        public void LateInitializeManager() { }


        public void SetSize(Vector2Int targetSize)
        {
            size = targetSize;
            background.localScale = new Vector3(targetSize.x, 0, targetSize.y);

            PixelEditorEvents.OnCanvasSizeSet?.Invoke();
        }

        public void SetBackgroundColor(Color color)
        {
            backgroundMesh.sharedMaterial.color = color;

            PixelEditorEvents.OnCanvasColorSet?.Invoke();
        }

        private void OnValidate()
        {
            SetSize(size);
        }
    }
}