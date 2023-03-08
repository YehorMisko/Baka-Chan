using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//A script so that the music never stops
public class DontDestroyAudio : MonoBehaviour
{
    public AudioSource myAudioSource;
    void Awake()
    {
            DontDestroyOnLoad(transform.gameObject);
    }
}
