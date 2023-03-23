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
    internal Animator anim;

    void Awake()   
    {
        anim= GetComponentInChildren<Animator>();
        tr= transform;
        yOriginal = tr.position.y;
        
    }
    

    void Update()
    {
        Horizontal += Input.GetAxis("Horizontal") * Speed * Time.deltaTime;

        if (!Jumping && !Sliding && Input.GetButtonDown("Jump"))
            StartCoroutine(fly());
        
        if (!Jumping && !Sliding && Input.GetButtonDown("Fire1"))
            StartCoroutine(slide());

        Horizontal = Mathf.Clamp(Horizontal, MaxLeft, MaxRight);

        tr.position = new Vector3(Horizontal, yOriginal + yOffset, 0);
        Pivot.rotation = Quaternion.Euler(xRotation, 0, 0);

    }
    //esto es el salto, le puse "fly" porque con el "jump" se me hubiesen mezclado las cosas.
    public IEnumerator fly() 
    {
        Jumping = true;
        anim.CrossFade("Jump", .1f);
        float d = 0;
        while (d < JumpDuration) 
        {
            d += Time.deltaTime;
            yOffset = JumpCurve.Evaluate(d/JumpDuration) * JumpScale;
            yield return null;
        }
        anim.CrossFade("Run", .1f);
        Jumping = false;
    }

    public IEnumerator slide() 
    {
        Sliding = true;
        float d = 0;
        anim.CrossFade("Slide", SlideUpDownDuration);

        while (d < SlideUpDownDuration) 
        {
            d += Time.deltaTime;
            xRotation = slideCurve.Evaluate(d/ SlideUpDownDuration) * SlideScale;
            yield return null;
        }

        yield return new WaitForSeconds(SlideDuration);
        anim.CrossFade("Run", SlideUpDownDuration);
        while (d > 0)
        {
            d -= Time.deltaTime;
            xRotation = slideCurve.Evaluate(d / SlideUpDownDuration) * SlideScale;
            yield return null;
        }

        Sliding = false;
    }
}
