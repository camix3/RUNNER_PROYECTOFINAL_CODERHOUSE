using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    Transform tr;
    public Transform Target;
    public float Speed = 5f;

    private void Awake()
    {
        tr = transform;
    }

    private void Update()
    {
        tr.position = Vector3.Lerp(tr.position, Target.position, Speed * Time.deltaTime);
    }
}
