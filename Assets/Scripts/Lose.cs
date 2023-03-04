using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject LoseScreen;
    public Generator generator;
    private void Awake()
    {
        Trap.OnTrap += Trap_Ontrap;
    }

    private void Trap_Ontrap(TrapType trapType) 
    {
       LoseScreen.SetActive(true);
        generator.enabled= false;
    }
    
   
}
