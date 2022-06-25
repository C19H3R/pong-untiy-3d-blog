using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//namespaces
using Pong.Utilities;


namespace Pong.Services.AudioServices
{

    public class AudioDataDictionary : Dictionary<AudioClipSFX_key, AudioClip> { }

    [CreateAssetMenu(fileName = "AudioDataContainer", menuName = "Services/DataContainers/AudioContainer", order = 1)]
    public class PongAudioSFXDataContainerSO : ScriptableObject
    {
        public AudioClip DefaultClip;
        [SerializeField]List<AudioClipSFX_key> AudioKeyList;
        [SerializeField]List<AudioClip> AudioClipList;

        public AudioDataDictionary AudioData
        {
            get
            {
                return PongUtility.ListToDictionary(AudioKeyList, AudioClipList) as AudioDataDictionary;
            }
        }
        
    }
}

