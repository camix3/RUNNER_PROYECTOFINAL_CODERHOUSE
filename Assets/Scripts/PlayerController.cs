using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private Vector2 inputMov;
    [SerializeField] private float speed = 10;
    Transform cam;
    private float rotX;
    [SerializeField] private float jumpForce = 130;
    [SerializeField] private int extraForce = 10;

    private float distanceToGround;
    




    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        distanceToGround= GetComponent<Collider>().bounds.extents.y;
    }

     
    void Update()
    {
        Movement();
    }

    public void Movement() 
    {
        //inputs movimiento
        inputMov.x= Input.GetAxis("Horizontal");
        rb.velocity = transform.forward.normalized * speed * inputMov.y
            + transform. right.normalized * speed * inputMov.x;
        
        //salto

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()) 
        {
            animator.SetTrigger("Jump");
            rb.AddForce (Vector3.up * jumpForce, ForceMode.Impulse);
        }
        rb.AddForce(extraForce * Physics.gravity);

    }
    private bool isGrounded() 
    {
        
        return Physics.BoxCast(transform.position, 
        new Vector3 (0.4f, 0f, 0.4f), Vector3.down, Quaternion.identity, distanceToGround + 0.1f);
    }

    

}
