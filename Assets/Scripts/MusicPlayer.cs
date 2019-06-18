using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HollowPoint
{
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour
    {
        [SerializeField] AudioClip music;
        static MusicPlayer m_instance;
        public static MusicPlayer instance {
            get {
                //Create a new intance if it doesn't exist
                if (m_instance == null) {
                    GameObject go = new GameObject();
                    m_instance = go.AddComponent<MusicPlayer>();
                }
                return m_instance;
            }
        }

        AudioSource audioSource;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        void Start()
        {
            if (music != null)
                audioSource.clip = music;

            audioSource.playOnAwake = true;
            audioSource.loop = true;
        }
    }
}