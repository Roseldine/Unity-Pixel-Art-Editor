
using UnityEngine;
using System.Collections.Generic;

namespace StardropTools.PlayerPreferences
{
    [CreateAssetMenu(menuName = "Stardrop / Player Preferences / Indexed List / Indexed List Int")]
    public class ScriptableIndexedPlayerPrefListIntSO : ScriptableIndexedPlayerPrefListSO
    {
        [Header("List")]
        [SerializeField] List<int> list;

        /// <summary>
        /// Get the value of the array at current Index
        /// </summary>
        public int IndexedInt => list[Index];

        /// <summary>
        /// Get the value of the array at current Index
        /// </summary>
        public int GetIndexedInt() => list[Index];

        /// <summary>
        /// Inserts value in the list
        /// </summary>
        public void AddValue(int valueToAdd) => list.Add(valueToAdd);

        /// <summary>
        /// Inserts value in the list ONLY if the list doesn't contain the same value
        /// </summary>
        public void SafeAddValue(int valueToAdd)
        {
            if (list.Contains(valueToAdd) == false)
                list.Add(valueToAdd);
        }

        /// <summary>
        /// Removes value from the list
        /// </summary>
        public void RemoveValue(int valueToRemove) => list.Remove(valueToRemove);


        /// <summary>
        /// Removes value from the list ONLY if the list contains the same value
        /// </summary>
        public void SafeRemoveValue(int valueToRemove)
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
            list = new List<int>();
        }
    }
}