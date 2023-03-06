using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float Horizontal;
    public float MaxLeft, MaxRight;

    public Transform Pivot;
    public AnimationCurve slideCurve;
    private bool Sliding = false;
    public float SlideUpDownDuration = 1f;
    public float SlideDuration = 0.1f;
    public float SlideScale = -90f;

    public AnimationCurve JumpCurve;
    private bool Jumping = false;
    public float JumpScale = 5f;
    public float JumpDuration = 0.9f;
    public float Speed;

    float yOriginal;
    float yOffset;
    float xRotation;

    internal Transform tr;
    internal Animator animator;
    void Awake()   
    {
        tr= transform;
        animator = GetComponent<Animator>();
        yOriginal = tr.position.y;
        
    }
    

    void Update()
    {
        Horizontal += Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        if (!Jumping && !Sliding && Input.GetButtonDown("Jump")) 
        {
            animator.SetTrigger("Jump");
            StartCoroutine(fly());

        }
        
        if (!Jumping && !Sliding && Input.GetButtonDown("Fire1"))
            StartCoroutine(slide());

        Horizontal = Mathf.Clamp(Horizontal, MaxLeft, MaxRight);

        tr.position = new Vector3(Horizontal, yOriginal + yOffset, 0);
        Pivot.rotation = Quaternion.Euler(xRotation, 0, 0);

    }
     
    public IEnumerator fly() //(JUMP)
    {
        Jumping = true;
        float d = 0;
        while (d < JumpDuration) 
        {        

            d += Time.deltaTime;
            yOffset = JumpCurve.Evaluate(d/JumpDuration) * JumpScale;
            yield return null;
        }              
        Jumping = false;
    }

    public IEnumerator slide() 
    {
        Sliding = true;
        float d = 0;

        while (d < SlideUpDownDuration) 
        {
            d += Time.deltaTime;
            xRotation = slideCurve.Evaluate(d/JumpDuration) * SlideScale;
            yield return null;
        }

        yield return new WaitForSeconds(SlideDuration);

        while (d > 0)
        {
            d -= Time.deltaTime;
            xRotation = slideCurve.Evaluate(d / JumpDuration) * SlideScale;
            yield return null;
        }

        Sliding = false;
    }
}
