using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [HideInInspector] public Slider volumeSlider;
    private AudioSource musicSource;
    private Scene lastScene;

    void Start()
    {
        volumeSlider = gameObject.GetComponent<Slider>();
        musicSource = Camera.main.GetComponent<AudioSource>();
    }

    public void UpdateVolume()
    {
        musicSource.volume = volumeSlider.value;
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() != lastScene)
        {
            musicSource = Camera.main.GetComponent<AudioSource>();
            UpdateVolume();
        }
        lastScene = SceneManager.GetActiveScene();
    }
}
