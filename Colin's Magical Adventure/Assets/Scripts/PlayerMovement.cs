using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public GameObject model;
    private Animator anim;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float speedMultiplier = 1f;
    public float jumpMultiplier = 1f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    public AudioSource stepSound;

    private void Start()
    {
        anim = model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("SheetOpen") == 0 && PlayerPrefs.GetInt("IsDead") == 0 && PlayerPrefs.GetInt("Victory") == 0)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = (transform.right * x + transform.forward * z) * speedMultiplier;

            if (move != Vector3.zero)
            {
                stepSound.loop = true;
                if (!stepSound.isPlaying)
                {
                    stepSound.Play();
                    anim.SetBool("isRunning", true);
                }
            }
            if (move == Vector3.zero)
            {
                anim.SetBool("isRunning", false);
                stepSound.Stop();
            }

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = (Mathf.Sqrt(jumpHeight * -2f * gravity)) * jumpMultiplier;
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        }
    }
}
