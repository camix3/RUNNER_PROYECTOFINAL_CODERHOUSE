using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image ImagenMute;

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        MuteCheck();
    }

    public void ChangeSlider(float value) 
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider .value;
        MuteCheck();
    }

    public void MuteCheck() 
    {
        if (sliderValue == 0) 
        {
            ImagenMute.enabled = true;
        }
        else 
        {
            ImagenMute.enabled = false;
        }
    }
}
