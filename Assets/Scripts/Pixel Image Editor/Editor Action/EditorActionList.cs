
using System.Collections.Generic;

namespace PixelEditor
{
    public static class EditorActionList
    {
        public static List<EditorAction> actionHistory;
        static bool isInitialized;

        /// <summary>
        /// Initialize a fresh new EditorActionList
        /// </summary>
        public static void Initialize()
        {
            if (isInitialized)
                return;

            actionHistory = new List<EditorAction>();
        }

        /// <summary>
        /// Add new EditorAction to the Action History
        /// </summary>
        public static void AddAction(EditorAction action) => actionHistory.Add(action);

        /// <summary>
        /// Clears all actions, making a new list
        /// </summary>
        public static void Clear()
        {
            actionHistory = new List<EditorAction>();
        }
    }
}