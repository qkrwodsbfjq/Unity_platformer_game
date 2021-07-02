//==========================================
// writer : Jae Yoon Park.
// file : SetSound.cs.
// content : Sound 컨트롤.
// descript: 
//==========================================


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSound : MonoBehaviour
{
    public AudioSource musicsource;

    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }

    //------------------------------------------------------------------------
}
