using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationEventsV2 : MonoBehaviour
{
    public AudioClip rifleSound;
    public AudioSource soundSource;

    void Start()
    {
        soundSource.clip = rifleSound;
    }

    void Update()
    {

    }

    void PlayRifleShot()
    { 
        soundSource.Play();
    }
}
