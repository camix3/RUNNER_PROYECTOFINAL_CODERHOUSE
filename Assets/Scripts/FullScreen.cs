using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreen : MonoBehaviour
{
    public Toggle toggle;
    public TMP_Dropdown resolutionDropDown;
    Resolution[] res;
    

    void Start()
    {
        if (Screen.fullScreen) 
        {
            toggle.isOn = true;
        }
        else 
        {
            toggle.isOn = false;
        }
        CheckResolution();
    }

    public void FullScreenOn(bool screenFull) 
    {
        Screen.fullScreen = screenFull;
    }

    public void CheckResolution()
    {
        res = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        List<string> options = new List<string>();
        int actualResolution = 0;

        for (int i = 0; i < res.Length; i++) 
        {
            string option = res[i].width + " x " + res[i].height;
            options.Add(option);

            if (Screen.fullScreen && res[i].width == Screen.currentResolution.width &&
                res[i].height == Screen.currentResolution.height)
            {
                actualResolution = i;
            }
        }

        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = actualResolution;
        resolutionDropDown.RefreshShownValue();

        resolutionDropDown.value = PlayerPrefs.GetInt("resolutionNumber", 0);
    }
    public void ChangeResolution(int ResolutionIndice) 
    {
        PlayerPrefs.SetInt("resolutionNumber", resolutionDropDown.value);
        Resolution resolution = res[ResolutionIndice];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
