using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string audioName;
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume;

        [Range(.1f, 3f)]
        public float pitch;

        [Range(0f, 1f)]
        public float spatialBlend;

        [HideInInspector]
        public AudioSource source;

    }

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
        //avoiding change scenes problem
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.spatialBlend = s.spatialBlend;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void Play(string name, float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.audioName == name);
        /*TEST
        s.source.volume = s.volume;
        s.source.spatialBlend = s.spatialBlend;*/
        s.source.volume = volume;
        s.source.pitch = s.pitch;
        s.source.PlayOneShot(s.clip, s.volume);
    }
}


