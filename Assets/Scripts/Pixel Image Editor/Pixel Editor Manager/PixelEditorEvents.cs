using System.Collections;
using UnityEngine;

namespace PixelEditor
{
    public static class PixelEditorEvents
    {
        // Editor
        public static readonly GameEvent OnInitialized = new GameEvent();

        // Pixel Canvas
        public static readonly GameEvent OnCanvasSizeSet = new GameEvent();
        public static readonly GameEvent OnCanvasColorSet = new GameEvent();

        // Paint Tools
        public static readonly GameEvent<PaintToolType> OnPaintToolSelected = new GameEvent<PaintToolType>();
        public static readonly GameEvent OnPaintActionStart = new GameEvent();
        public static readonly GameEvent<EditorAction> OnPaintActionEnd = new GameEvent<EditorAction>();

        public static readonly GameEvent PixelSpawnRequest = new GameEvent();
    }
}