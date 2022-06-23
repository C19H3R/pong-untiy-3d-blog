using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pong.Services.AudioServices
{

    public class PongAudioControllerService
    {
        public void PlaySFX(AudioSource source,AudioClip sfx)
        {
            source.clip = sfx;
            source.Play();
        }

        public void SetAudioSourceVolume(AudioSource source,float volume)
        {
            source.volume = volume;
        }

        ~PongAudioControllerService(){ }
    }
}

