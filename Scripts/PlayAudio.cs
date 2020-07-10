/*
 Authored by Gabriel Santa Maria
 Copyright 2020 Artificial Illusions
 www.artificialillusions.vision

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource _audioClip;
   

    public void PlayAudioClip()
    {
        _audioClip.Play(0);
    }
}
