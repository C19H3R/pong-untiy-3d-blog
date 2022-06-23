using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespaces
using Pong.Services.DataContainer;

namespace Pong.Services.AudioServices
{
    public class PongAudioPlayerService : MonoBehaviour
    {
        [SerializeField]AudioSource sfxAudioSource;

        [HideInInspector] public PongAudioControllerService AudioControllerService { get; set; }
        [HideInInspector] public PongDataContainerService DataContainerService { get; set; }



        public void PlaySFX(AudioClipSFX_key key)
        {
            AudioControllerService.PlaySFX(sfxAudioSource, DataContainerService.GetAudioSFXClip(key)); 
        }
    }

}

