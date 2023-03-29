using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip clip;
   private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Player") 
        {
            Scores.Instance.current.Collectable++;
            AudioHolder.Instance.Play(clip);
            gameObject.SetActive(false); //se desactivan los coleccionables para poder reutilizarlos en vez de destruírlos.
        }
    }

}
