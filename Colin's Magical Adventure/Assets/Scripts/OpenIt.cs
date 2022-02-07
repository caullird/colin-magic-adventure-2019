using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenIt : MonoBehaviour
{
    Animator animator;
    public bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Hand")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Key a down");
                /*animation.Play("OpenDoor");
                isAnimated = true;*/
                if (!animator.GetBool("isOpen"))
                {
                    animator.SetBool("isOpen", true);
                }
                else
                {
                    animator.SetBool("isOpen", false);
                }
            }


            //Debug.Log("collision with player");
        }

    }
}
