using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespaces
using Pong.Services.AudioServices;
using Pong.Services.DataContainer;

namespace Pong.Services
{
    public class PongServiceLocator : MonoBehaviour
    {
        [SerializeField] PongDataContainerService pongDataContainerService;
        [SerializeField] PongAudioPlayerService pongAudioPlayerService;


        static PongAudioControllerService _audioControllerService = new();
        static PongDataContainerService _pongDataContainerService;
        static PongAudioPlayerService _pongAudioPlayerService;



        private void Start()
        {
            _pongDataContainerService = pongDataContainerService;
            _pongAudioPlayerService = pongAudioPlayerService;

            _pongAudioPlayerService.AudioControllerService = _audioControllerService;
            _pongAudioPlayerService.DataContainerService = _pongDataContainerService;

        }

        /// <summary>
        /// getter for Audio Controller Service
        /// </summary>
        public static PongAudioControllerService AudioControllerService
        {
            get
            {
                return _audioControllerService;
            }
        }
        
        /// <summary>
        /// getter for data Container Service
        /// </summary>
        public static PongDataContainerService DataContainerService
        {
            get
            {
                return _pongDataContainerService;

            }
        }

        /// <summary>
        /// getter for audio player service
        /// </summary>
        public static PongAudioPlayerService AudioPlayerService
        {
            get
            {
                return _pongAudioPlayerService;
            }
        }

    }
}

