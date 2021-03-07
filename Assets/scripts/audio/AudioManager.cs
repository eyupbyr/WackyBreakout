using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager 
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }

    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.ButtonClicked, Resources.Load<AudioClip>("ButtonClicked"));
        //audioClips.Add(AudioClipName.BlockDestroyed, Resources.Load<AudioClip>("BlockDestroyed"));
    }

    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }


}
