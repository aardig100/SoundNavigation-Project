using OVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundConfiguration : MonoBehaviour
{
    [SerializeField]
    AudioSource[] sources;
    [SerializeField]
    AudioClip[] clips;


    private void OnEnable()
    {
        for (int i = 0; i < sources.Length; i ++)
        {
            sources[i].clip = clips[i];
            sources[i].Play();
        }
    }


}
