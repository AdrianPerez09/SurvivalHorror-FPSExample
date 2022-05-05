using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Animator anim;
    public Transform playerTransform;

    public float speed = 4f;
    public float walkSpeed = 2f;
    public float gravity = -9.81f;
    public float sprintMultiplier;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Rigidbody rbPlayer;
    Vector3 velocity;
    bool isGrounded;
    bool isSprinting;
    bool isColliding;

    float x;
    float z;

    private void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;

        if (isSprinting)
        {
            move *= sprintMultiplier;
        }

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        anim.SetFloat("horizontal", x);
        anim.SetFloat("vertical", z);


        //Solo se podrá esprintar hacia delante.
        if (Input.GetKey(KeyCode.LeftShift) && z == 1 && !isColliding)
        {
            isSprinting = true;
            anim.SetBool("is_running", true);
        }
        else
        {
            isSprinting = false;
            anim.SetBool("is_running", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetFloat("horizontal", 0);
        anim.SetFloat("vertical", 0);

        print("collision detected");

        isColliding = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isColliding = false;
    }
}
