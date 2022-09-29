
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [CreateAssetMenu(menuName = "Stardrop / Player Preferences / Value / Player Pref Int")]
    public class PlayerPrefIntSO : ScriptableObject
    {
        [SerializeField] PlayerPrefInt prefInt;
        [SerializeField] bool resetToStart;
        [SerializeField] bool load;
        [SerializeField] bool reset;

        public int Int => prefInt.GetInt();

        public GameEvent OnValueChange => prefInt.OnValueChange;
        public GameEvent<int> OnIntChange => prefInt.OnIntChange;

        public void SetInt(int value, bool save = false) => prefInt.SetInt(value, save);
        public int LoadInt() => prefInt.GetInt(true);

        public float AddValue(int valueToAdd, bool save = false) => prefInt.AddValue(valueToAdd, save);

        public float RemoveValue(int valueToRemove, bool save = false) => prefInt.RemoveValue(valueToRemove, save);

        public void ResetToStartValue() => prefInt.ResetToStartValue();


        private void OnValidate()
        {
            prefInt.SetValueType();

            if (load)
            {
                prefInt.LoadValue();
                load = false;
            }

            if (reset)
            {
                prefInt.Initialize();
                reset = false;
            }

            if (resetToStart)
            {
                prefInt.ResetToStartValue();
                resetToStart = false;
            }
        }
    }
}