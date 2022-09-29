
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [System.Serializable]
    public class PlayerPrefInt : PlayerPrefBaseValue
    {
        [SerializeField] int startInt;
        [SerializeField] int value;

        public int Int => value;

        public readonly GameEvent<int> OnIntChange = new GameEvent<int>();

        public override void SetValueType() => prefValue.SetValueType(PlayerPrefValueType.INT);

        public override void Initialize()
        {
            prefValue = new PlayerPrefValue(startInt);
            LoadValue();
        }

        public override void LoadValue()
        {
            value = prefValue.GetInt();

            OnValueChange?.Invoke();
            OnIntChange?.Invoke(value);
        }

        public void SetInt(int value, bool save = false)
        {
            prefValue.SetInt(value, save);
            this.value = value;

            OnValueChange?.Invoke();
            OnIntChange?.Invoke(value);
        }

        public int GetInt(bool load = false)
        {
            if (load)
                LoadValue();

            return value;
        }

        public int AddValue(int valueToAdd, bool save = false)
        {
            value += valueToAdd;
            prefValue.SetInt(value, save);

            return value;
        }

        public int RemoveValue(int valueToRemove, bool save = false)
        {
            value -= valueToRemove;
            prefValue.SetInt(value, save);

            return value;
        }

        public override void ResetToStartValue() => SetInt(startInt, true);
    }
}