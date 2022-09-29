
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [CreateAssetMenu(menuName = "Stardrop / Player Preferences / Value / Player Pref Float")]
    public class PlayerPrefFloatSO : ScriptableObject
    {
        [SerializeField] PlayerPrefFloat prefFloat;
        [SerializeField] bool resetToStart;
        [SerializeField] bool load;
        [SerializeField] bool reset;

        public float Float => prefFloat.GetFloat();

        public GameEvent OnValueChange => prefFloat.OnValueChange;
        public GameEvent<float> OnFloatChange => prefFloat.OnFloatChange;

        public void SetFloat(float value, bool save = false) => prefFloat.SetFloat(value, save);
        public float LoadFloat() => prefFloat.GetFloat(true);

        public float AddValue(float valueToAdd, bool save = false) => prefFloat.AddValue(valueToAdd, save);

        public float RemoveValue(float valueToRemove, bool save = false) => prefFloat.RemoveValue(valueToRemove, save);

        public void ResetToStartValue() => prefFloat.ResetToStartValue();


        private void OnValidate()
        {
            prefFloat.SetValueType();

            if (load)
            {
                prefFloat.LoadValue();
                load = false;
            }

            if (reset)
            {
                prefFloat.Initialize();
                reset = false;
            }

            if (resetToStart)
            {
                prefFloat.ResetToStartValue();
                resetToStart = false;
            }
        }
    }
}