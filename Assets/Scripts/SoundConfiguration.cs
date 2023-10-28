using OVR;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundConfiguration : MonoBehaviour
{
    [SerializeField]
    AudioSource[] positiveSources;
    [SerializeField]
    AudioSource[] negativeSources;
    [SerializeField]
    AudioClip[] positiveClips;
    [SerializeField]
    AudioClip[] negativeClips;


    private void OnEnable()
    {
        for(int i = 0; i < positiveSources.Length; i ++)
        {
            positiveSources[i].clip = positiveClips[i];
            positiveSources[i].Play();
        }

        for(int i = 0; i < negativeSources.Length; i ++)
        {
            negativeSources[i].clip = negativeClips[i];
            negativeSources[i].Play();
        }

        if(StateData.soundConfiguration == 1)
        {
            foreach (AudioSource source in positiveSources)
            {
                source.enabled = false;
            }
        }
        else if(StateData.soundConfiguration == 2)
        {
            foreach(AudioSource source in negativeSources)
            {
                source.enabled = false;
            }
        }


    }

}
