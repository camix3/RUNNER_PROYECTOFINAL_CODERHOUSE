using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    static public event TrapEvent OnTrap;
    public TrapType trapType = TrapType.impact;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            OnTrap?.Invoke(trapType);
        }

    }

    private void OnDestroy()
    {
        OnTrap = null;
    }

}

public delegate void TrapEvent(TrapType trapType);

public enum TrapType 
{
    impact,
}
