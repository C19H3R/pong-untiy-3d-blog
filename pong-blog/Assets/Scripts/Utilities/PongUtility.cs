using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pong.Utilities
{
    public static class PongUtility 
    {
        /// <summary>
        /// Utility Function to get dictionary from two list of keys and values inside a data container
        /// </summary>
        /// <typeparam name="TKey">key Type</typeparam>
        /// <typeparam name="TVal">value Type</typeparam>
        /// <param name="keysList">list of keys from data conatainer</param>
        /// <param name="valuesList">list of values from data container</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public static Dictionary<TKey,TVal> ListToDictionary<TKey,TVal>(List<TKey> keysList, List<TVal> valuesList)
        {
            //check : key and value count
            if (keysList.Count != valuesList.Count)
            {
                throw new System.Exception("Difference in number of keys and number of values");
            }

            //check : no two key same
            HashSet<TKey> keyHash= new();

            foreach (TKey key in keysList)
            {
                if (keyHash.Contains(key))
                {
                    throw new System.Exception("Same key found");
                }

                keyHash.Add(key);
            }

            //result to return 
            Dictionary<TKey, TVal> result = new();

            //itration counter
            int index = 0;

            foreach (TKey key in keysList)
            {
                result.Add(key, valuesList[index]);
                index++;
            }

            return result;
        }
    }

}

