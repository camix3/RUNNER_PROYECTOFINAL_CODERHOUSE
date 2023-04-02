using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twitch_follow: MonoBehaviour
{
  
    public void twitch_Follow(string enlace) 
    {
        Application.OpenURL(enlace);
    }
}
