
using UnityEngine;
using System.Collections.Generic;

namespace StardropTools.PlayerPreferences
{
    [CreateAssetMenu(menuName = "Stardrop / Player Preferences / Indexed List / Indexed List String")]
    public class ScriptableIndexedPlayerPrefListStringSO : ScriptableIndexedPlayerPrefListSO
    {
        [Header("List")]
        [SerializeField] List<string> list;

        /// <summary>
        /// Get the value of the array at current Index
        /// </summary>
        public string IndexedString => list[Index];

        /// <summary>
        /// Get the value of the array at current Index
        /// </summary>
        public string GetIndexedString() => list[Index];

        /// <summary>
        /// Inserts value in the list
        /// </summary>
        public void AddValue(string valueToAdd) => list.Add(valueToAdd);

        /// <summary>
        /// Inserts value in the list ONLY if the list doesn't contain the same value
        /// </summary>
        public void SafeAddValue(string valueToAdd)
        {
            if (list.Contains(valueToAdd) == false)
                list.Add(valueToAdd);
        }

        /// <summary>
        /// Removes value from the list
        /// </summary>
        public void RemoveValue(string valueToRemove) => list.Remove(valueToRemove);


        /// <summary>
        /// Removes value from the list ONLY if the list contains the same value
        /// </summary>
        public void SafeRemoveValue(string valueToRemove)
        {
            if (list.Contains(valueToRemove) == true)
                list.Remove(valueToRemove);
        }

        /// <summary>
        /// Clears list, making a new list
        /// </summary>
        public void ClearList()
        {
            SetIndex(0);
            list = new List<string>();
        }
    }
}