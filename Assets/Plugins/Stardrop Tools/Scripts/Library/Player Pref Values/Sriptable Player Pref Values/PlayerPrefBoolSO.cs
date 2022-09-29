
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [CreateAssetMenu(menuName = "Stardrop / Player Preferences / Value / Player Pref Bool")]
    public class PlayerPrefBoolSO : ScriptableObject
    {
        [SerializeField] PlayerPrefBool prefBool;
        [SerializeField] bool resetToStart;
        [SerializeField] bool load;
        [SerializeField] bool reset;

        public bool Bool => prefBool.GetBool();

        public GameEvent OnValueChange => prefBool.OnValueChange;
        public GameEvent<bool> OnBoolChange => prefBool.OnBoolChange;

        public void SetBool(bool value, bool save = false) => prefBool.SetBool(value, save);
        public bool LoadBool() => prefBool.GetBool(true);

        public void ResetToStartValue() => prefBool.ResetToStartValue();

        private void OnValidate()
        {
            prefBool.SetValueType();

            if (load)
            {
                prefBool.LoadValue();
                load = false;
            }

            if (reset)
            {
                prefBool.Initialize();
                reset = false;
            }

            if (resetToStart)
            {
                prefBool.ResetToStartValue();
                resetToStart = false;
            }
        }
    }
}