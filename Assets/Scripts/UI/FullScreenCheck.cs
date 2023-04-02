using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullScreenCheck : MonoBehaviour
{
    public Toggle toggle;

    private void Start()
    {
        if (Screen.fullScreen) 
        {
            toggle.isOn = true;
        }
        else 
        {
            toggle.isOn = false;
        }
    }

    private void Update()
    {
        
    }

    public void FullScreenOn(bool fullScreen) 
    {
        Screen.fullScreen = fullScreen;
    }
}
