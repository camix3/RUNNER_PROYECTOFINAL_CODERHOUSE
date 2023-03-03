using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Horizontal;
    public float MaxLeft, MaxRight;
    public float MaxBack, MaxFor;

    public float Speed;

    float yOriginal;

    internal Transform tr;

    void Awake()   
    {
        tr= transform;
        yOriginal = tr.position.y;
        
    }
    

    void Update()
    {

        Horizontal += Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        Horizontal = Mathf.Clamp(Horizontal, MaxLeft, MaxRight);

        tr.position = new Vector3(Horizontal, yOriginal, 0);

    }

}
