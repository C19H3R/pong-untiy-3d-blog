using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//namespaces
using Pong.Utilities;


namespace Pong.Services.AudioServices
{


    [CreateAssetMenu(fileName = "AudioDataContainer", menuName = "Services/DataContainers/AudioContainer", order = 1)]
    public class PongAudioSFXDataContainerSO : ScriptableObject
    {
        public AudioClip DefaultClip;
        [SerializeField]List<AudioClipSFX_key> AudioKeyList;
        [SerializeField]List<AudioClip> AudioClipList;

        public Dictionary<AudioClipSFX_key, AudioClip> AudioData
        {
            get
            {
                return PongUtility.ListToDictionary(AudioKeyList, AudioClipList);
            }
        }
        
    }
}

