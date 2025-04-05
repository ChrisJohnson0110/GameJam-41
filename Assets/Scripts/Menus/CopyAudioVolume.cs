using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyAudioVolume : MonoBehaviour
{
    void Start()
    {
        if (GameObject.FindObjectOfType<VolumeSlider>() != null)
        {
            gameObject.GetComponent<AudioSource>().volume = GameObject.FindObjectOfType<VolumeSlider>().volumeSlider.value;
        }
    }
}
