
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [System.Serializable]
    public class PlayerPrefString : PlayerPrefBaseValue
    {
        [SerializeField] string startString;
        [SerializeField] string value;

        public string String => value;

        public readonly GameEvent<string> OnStringChange = new GameEvent<string>();

        public override void SetValueType() => prefValue.SetValueType(PlayerPrefValueType.STRING);

        public override void Initialize()
        {
            prefValue = new PlayerPrefValue(startString);
            LoadValue();
        }

        public override void LoadValue()
        {
            value = prefValue.GetString();

            OnValueChange?.Invoke();
            OnStringChange?.Invoke(value);
        }

        public void SetString(string value, bool save = false)
        {
            prefValue.SetString(value, save);
            this.value = value;

            OnValueChange?.Invoke();
            OnStringChange?.Invoke(value);
        }

        public string GetString(bool load = false)
        {
            if (load)
                LoadValue();

            return value;
        }

        public override void ResetToStartValue() => SetString(startString, true);
    }
}