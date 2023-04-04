using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_menu : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool menuOn;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            menuOn = !menuOn;
        }

        if(menuOn==true) 
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            
        }
        else 
        {
            menuDesactivated();
           
        }
    }

    public void Continue() 
    {
        menuDesactivated();
        menuOn = false;
    }

    private void menuDesactivated() 
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }
}
