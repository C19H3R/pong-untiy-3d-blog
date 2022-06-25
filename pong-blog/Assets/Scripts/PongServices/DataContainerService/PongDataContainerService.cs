using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//namespaces
using Pong.Services.AudioServices;

namespace Pong.Services.DataContainer
{
    public class PongDataContainerService : MonoBehaviour
    {

        [SerializeField]PongAudioSFXDataContainerSO pongAudioDataContainerSO;

        #region Private Dictionaries

        private Dictionary<AudioClipSFX_key, AudioClip> audioDataDictionary;

        #endregion

        #region MonoBehaviour Callbacks

        private void Start()
        {
            //setting up private dictionaries
            audioDataDictionary = pongAudioDataContainerSO.AudioData;
        }

        #endregion

        #region GetDataMethods
        /// <summary>
        /// Get Audio clip with respect to key
        /// </summary>
        /// <param name="key">audio key</param>
        /// <returns></returns>
        public AudioClip GetAudioSFXClip(AudioClipSFX_key key)
        {
            if (!audioDataDictionary.ContainsKey(key))
            {
                return pongAudioDataContainerSO.DefaultClip;
            }
            else if (audioDataDictionary[key]==null)
            {
                return pongAudioDataContainerSO.DefaultClip;
            }
            return audioDataDictionary[key];
        }
        #endregion
    }

}
