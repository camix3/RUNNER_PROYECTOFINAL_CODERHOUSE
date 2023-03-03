using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Texter;
    public int TimesDead = 0;
    private void Awake()
    {
        Trap.OnTrap += Trap_Ontrap;
    }

    private void Trap_Ontrap(TrapType trapType) 
    {
        TimesDead++;
        Texter.text = $"You are Dead! { TimesDead }";
    }
    // Update is called once per frame
   
}
