
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    public abstract class ScriptableIndexedPlayerPrefListSO : ScriptableObject
    {
        [Header("Index")]
        [NaughtyAttributes.ResizableTextArea] [TextArea] [SerializeField] protected string description;
        [Space]
        [SerializeField] protected bool resetToStart;
        [SerializeField] protected PlayerPrefInt prefInt;

        /// <summary>
        /// Int value from the PlayerPrefInt
        /// </summary>
        public int Index => prefInt.Int;

        public void ResetToStartValue() => prefInt.ResetToStartValue();

        public void SetIndex(int index, bool save = false) => prefInt.SetInt(index, save);

        public void IncrementIndex(bool save = false) => prefInt.SetInt((int)Mathf.Clamp(prefInt.Int + 1, 0, Mathf.Infinity), save);

        public void DecrementIndex(bool save = false) => prefInt.SetInt((int)Mathf.Clamp(prefInt.Int - 1, 0, Mathf.Infinity), save);

        public int LoadIndex()
        {
            prefInt.LoadValue();
            return Index;
        }

        protected virtual void OnValidate()
        {
            prefInt.SetValueType();

            if (resetToStart)
            {
                prefInt.ResetToStartValue();
                resetToStart = false;
            }
        }
    }
}