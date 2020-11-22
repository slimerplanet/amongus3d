using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public Animator animator;

    public float speed = 12f;
    public float gravity = -9.81f;

    public Transform groundCheck;
    public float GroundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;

    TaskManager manager;

    bool isGrounded;
    [HideInInspector]
    public bool intask;
    
    
    

    private void Update()
    {
        if (manager.isIntask)
            return;

        isGrounded = Physics.CheckSphere(groundCheck.position, GroundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(x != 0 || z != 0)
        {
            animator.SetBool("walking", true);
        }else
        {
            animator.SetBool("walking", false);
        }
    }

    private void Start()
    {
        manager = FindObjectOfType<TaskManager>();
    }
}
