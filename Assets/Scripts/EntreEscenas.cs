using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntreEscenas : MonoBehaviour
{
    
    
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Opciones");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        DontDestroyOnLoad(gameObject);
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
