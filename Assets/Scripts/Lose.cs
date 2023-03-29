using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public GameObject LoseScreen;
    public Generator generator;
    public Move move;

    public TMPro.TextMeshProUGUI scoreText;
    private void Awake()
    {
        Trap.OnTrap += Trap_Ontrap;
    }

    private void Trap_Ontrap(TrapType trapType) 
    {
        scoreText.text = Scores.Instance.current.ToString();
        move.enabled = false;
        Scores.Instance.Save();
       LoseScreen.SetActive(true);
        generator.enabled= false;
    }
    
   
}
