
using UnityEngine;
using System.Collections.Generic;

namespace StardropTools.PlayerPreferences
{
    [CreateAssetMenu(menuName = "Stardrop / Player Preferences / Indexed List / Indexed List Float")]
    public class ScriptableIndexedPlayerPrefListFloatSO : ScriptableIndexedPlayerPrefListSO
    {
        [Header("List")]
        [SerializeField] List<float> list;

        /// <summary>
        /// Get the value of the array at current Index
        /// </summary>
        public float IndexedFloat => list[Index];

        /// <summary>
        /// Get the value of the array at current Index
        /// </summary>
        public float GetIndexedFloat() => list[Index];

        /// <summary>
        /// Inserts value in the list
        /// </summary>
        public void AddValue(float valueToAdd) => list.Add(valueToAdd);

        /// <summary>
        /// Inserts value in the list ONLY if the list doesn't contain the same value
        /// </summary>
        public void SafeAddValue(float valueToAdd)
        {
            if (list.Contains(valueToAdd) == false)
                list.Add(valueToAdd);
        }

        /// <summary>
        /// Removes value from the list
        /// </summary>
        public void RemoveValue(float valueToRemove) => list.Remove(valueToRemove);


        /// <summary>
        /// Removes value from the list ONLY if the list contains the same value
        /// </summary>
        public void SafeRemoveValue(float valueToRemove)
        {
            if (list.Contains(valueToRemove) == true)
                list.Remove(valueToRemove);
        }

        public void ClearList() => list = new List<float>();
    }
}