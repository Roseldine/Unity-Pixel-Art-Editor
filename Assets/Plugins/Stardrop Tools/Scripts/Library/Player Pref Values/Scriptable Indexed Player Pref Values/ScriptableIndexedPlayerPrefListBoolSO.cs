
using UnityEngine;
using System.Collections.Generic;

namespace StardropTools.PlayerPreferences
{
    [CreateAssetMenu(menuName = "Stardrop / Player Preferences / Indexed List / Indexed List Bool")]
    public class ScriptableIndexedPlayerPrefListBoolSO : ScriptableIndexedPlayerPrefListSO
    {
        [Header("List")]
        [SerializeField] List<bool> list;

        /// <summary>
        /// Get the value of the array at current Index
        /// </summary>
        public bool IndexedBool => list[Index];

        /// <summary>
        /// Get the value of the array at current Index
        /// </summary>
        public bool GetIndexedBool() => list[Index];


        /// <summary>
        /// Inserts value in the list
        /// </summary>
        public void AddValue(bool valueToAdd) => list.Add(valueToAdd);

        /// <summary>
        /// Inserts value in the list ONLY if the list doesn't contain the same value
        /// </summary>
        public void SafeAddValue(bool valueToAdd)
        {
            if (list.Contains(valueToAdd) == false)
                list.Add(valueToAdd);
        }

        /// <summary>
        /// Removes value from the list
        /// </summary>
        public void RemoveValue(bool valueToRemove) => list.Remove(valueToRemove);


        /// <summary>
        /// Removes value from the list ONLY if the list contains the same value
        /// </summary>
        public void SafeRemoveValue(bool valueToRemove)
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
            list = new List<bool>();
        }
    }
}