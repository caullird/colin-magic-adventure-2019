using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Player;
    float moveSpeed = 2f;
    int minDist = 2;
    int maxDist = 10;
    bool running;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        // targetObject = GameObject.FindGameObjectWithTag("Player") as GameObject;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) <= maxDist)
        {
            if (Vector3.Distance(transform.position, Player.position) >= minDist)
            {
                anim.SetBool("running", true);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;

            }
            if (Vector3.Distance(transform.position, Player.position) <= minDist)
            {
                anim.SetBool("running", false);
            }
        }
        






        /*if (targetObject == null)
    {
        Debug.Log("[ERROR] => Traget object is null , Can't Rotate");
        return;
    }
    Vector3 targetPosition = targetObject.transform.position;
    Quaternion targetRotation = Quaternion.LookRotation(targetPosition - transform.position);


    targetRotation.z = 0;

    targetRotation.x = 0;
    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    movement = targetPosition - transform.position;*/
    }
   /* private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }*/
}