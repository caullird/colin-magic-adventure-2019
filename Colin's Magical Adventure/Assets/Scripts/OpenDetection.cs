using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDetection : MonoBehaviour
{
    BoxCollider boxCollider;
    Animator animator;
    public AudioSource open;
    public AudioSource close;
    private float timer = 0.5f;
    private bool timerIsPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsPlaying)
        {
            timer -= Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider other){
        
        if (other.gameObject.name == "Hand")
        {
            if (Input.GetKey(KeyCode.E))
            {
                /*animation.Play("OpenDoor");
                isAnimated = true;*/
                if (!animator.GetBool("isOpen"))
                {
                    animator.SetBool("isOpen", true);
                    open.Play();
                    timerIsPlaying = true;
                }
                else if(timer <= 0)
                {
                    animator.SetBool("isOpen", false);
                    close.PlayDelayed(0.5f);
                }
            }
                

            //Debug.Log("collision with player");
        }

    }

    void OnTriggerExit(Collider other)
    {
        /*GameObject newNeighbor = other.GetComponent<CapsuleCollider>().gameObject;
        if (newNeighbor.tag == "Player")
        {
            animator.SetBool("isOpen", false);
        }*/
    }

    public void openDoor()
    {
        animator.SetBool("isOpen", true);
    }
    public void closeDoor()
    {
        animator.SetBool("isOpen", false);
    }
}
