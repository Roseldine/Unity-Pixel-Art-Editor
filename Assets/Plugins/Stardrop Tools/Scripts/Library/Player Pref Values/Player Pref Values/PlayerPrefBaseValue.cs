
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [System.Serializable]
    public abstract class PlayerPrefBaseValue
    {
        [SerializeField] protected PlayerPrefValue prefValue;

        public abstract void SetValueType();

        public abstract void Initialize();
        public abstract void LoadValue();

        public abstract void ResetToStartValue();

        public readonly GameEvent OnValueChange = new GameEvent();
    }
}