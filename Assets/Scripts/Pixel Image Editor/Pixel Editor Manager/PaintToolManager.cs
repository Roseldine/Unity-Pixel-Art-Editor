using System.Collections;
using UnityEngine;
using StardropTools;
using StardropTools.Pool;
using System.Collections.Generic;

namespace PixelEditor
{
    public class PaintToolManager : Singleton<PaintToolManager>, IManager
    {
        [Header("Pool")]
        [SerializeField] Pool<Pixel> pixelPool;

        [Header("Tools")]
        [SerializeField] PaintTool[] paintTools;

        public static Color CurrentColor = Color.gray;


        public void InitializeManager()
        {
            pixelPool.Populate();

            PixelEditorEvents.OnPaintToolSelected.AddListener(ActivateTool);
        }

        public void LateInitializeManager() { }


        /// <summary>
        /// 0-brush, 1-eraser, 2-line, 3-fill
        /// </summary>
        public void ActivateTool(int toolID)
        {
            for (int i = 0; i < paintTools.Length; i++)
            {
                var tool = paintTools[i];

                if (i != toolID && tool.IsActive == true)
                    tool.ActivateTool(false);
            }

            paintTools[toolID].ActivateTool(true);
        }

        void ActivateTool(PaintToolType toolType) => ActivateTool((int)toolType);

        public Pixel SpawnPixel(Vector3 position)
        {
            Pixel pixel = pixelPool.Spawn(position, Quaternion.identity, null);

            return pixel;
        }

        public void DespawnAllPixels() => pixelPool.DespawnAll(false);
    }
}