
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [System.Serializable]
    public class PlayerPrefFloat : PlayerPrefBaseValue
    {
        [SerializeField] float startFloat;
        [SerializeField] float value;

        public float Float => value;

        public readonly GameEvent<float> OnFloatChange = new GameEvent<float>();

        public override void SetValueType() => prefValue.SetValueType(PlayerPrefValueType.FLOAT);

        public override void Initialize()
        {
            prefValue = new PlayerPrefValue(startFloat);
            LoadValue();
        }

        public override void LoadValue()
        {
            value = prefValue.GetFloat();

            OnValueChange?.Invoke();
            OnFloatChange?.Invoke(value);
        }

        public void SetFloat(float value, bool save = false)
        {
            prefValue.SetFloat(value, save);
            this.value = value;

            OnValueChange?.Invoke();
            OnFloatChange?.Invoke(value);
        }

        public float GetFloat(bool load = false)
        {
            if (load)
                LoadValue();

            return value;
        }

        public float AddValue(float valueToAdd, bool save = false)
        {
            value += valueToAdd;
            prefValue.SetFloat(value, save);

            return value;
        }

        public float RemoveValue(float valueToRemove, bool save = false)
        {
            value -= valueToRemove;
            prefValue.SetFloat(value, save);

            return value;
        }

        public override void ResetToStartValue() => SetFloat(startFloat, true);
    }
}