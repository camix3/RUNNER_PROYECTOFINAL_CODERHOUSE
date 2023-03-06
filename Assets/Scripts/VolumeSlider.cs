using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imageMute;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = slider.value;
        ImMuted();
    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        ImMuted();
    }

    public void ImMuted() 
    {
        if (sliderValue == 0) 
        {
            imageMute.enabled = true;
        }
        else 
        {
            imageMute.enabled = false;
        }
    }
}
