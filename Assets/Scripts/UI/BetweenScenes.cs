using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScenes : MonoBehaviour
{
    private void Awake()
    {
        var notDestroy = FindObjectsOfType<BetweenScenes>();        
        if (notDestroy.Length > 1 ) 
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
