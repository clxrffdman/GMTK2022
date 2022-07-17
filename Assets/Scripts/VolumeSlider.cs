using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public int index;
    public AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        if (index == 0)
        {
            float value;
            bool result = mixer.GetFloat("musicVolume", out value);
            GetComponent<Slider>().value = value;
        }
        else
        {
            float value;
            bool result = mixer.GetFloat("sfxVolume", out value);
            GetComponent<Slider>().value = value;
        }
    }

    public void UpdateFX(float volume)
    {
        if(index == 0)
        {
            AudioManager.Instance.SetMusicVolume(volume);
        }
        else
        {
            AudioManager.Instance.SetSFXVolume(volume);
        }
    }
}
