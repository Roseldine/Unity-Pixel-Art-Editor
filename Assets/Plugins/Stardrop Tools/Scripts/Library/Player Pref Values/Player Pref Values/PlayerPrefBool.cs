
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [System.Serializable]
    public class PlayerPrefBool : PlayerPrefBaseValue
    {
        [SerializeField] bool startBool;
        [SerializeField] bool value;

        public bool Bool => value;

        public readonly GameEvent<bool> OnBoolChange = new GameEvent<bool>();

        public override void SetValueType() => prefValue.SetValueType(PlayerPrefValueType.BOOLEAN);

        public override void Initialize()
        {
            prefValue = new PlayerPrefValue(startBool);
            LoadValue();
        }

        public override void LoadValue()
        {
            value = prefValue.GetBool();

            OnValueChange?.Invoke();
            OnBoolChange?.Invoke(value);
        }

        public void SetBool(bool value, bool save = false)
        {
            prefValue.SetBool(value, save);
            this.value = value;

            OnValueChange?.Invoke();
            OnBoolChange?.Invoke(value);
        }

        public bool GetBool(bool load = false)
        {
            if (load)
                LoadValue();

            return value;
        }

        public override void ResetToStartValue() => SetBool(startBool, true);
    }
}