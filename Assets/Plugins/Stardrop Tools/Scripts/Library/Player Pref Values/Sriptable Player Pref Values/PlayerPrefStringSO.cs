
using UnityEngine;

namespace StardropTools.PlayerPreferences
{
    [CreateAssetMenu(menuName = "Stardrop / Player Preferences / Value / Player Pref String")]
    public class PlayerPrefStringSO : ScriptableObject
    {
        [SerializeField] PlayerPrefString prefString;
        [SerializeField] bool resetToStart;
        [SerializeField] bool load;
        [SerializeField] bool reset;

        public string String => prefString.GetString();

        public GameEvent OnValueChange => prefString.OnValueChange;
        public GameEvent<string> OnStringChange => prefString.OnStringChange;

        public void SetString(string value, bool save = false) => prefString.SetString(value, save);
        public string LoadString() => prefString.GetString(true);


        private void OnValidate()
        {
            prefString.SetValueType();

            if (load)
            {
                prefString.LoadValue();
                load = false;
            }

            if (reset)
            {
                prefString.Initialize();
                reset = false;
            }

            if (resetToStart)
            {
                prefString.ResetToStartValue();
                resetToStart = false;
            }
        }
    }
}