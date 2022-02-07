using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetItFlow : MonoBehaviour
{
    public AudioSource audioSource;
    private bool flowing = false;


    void Update()
    {
        if (!audioSource.isPlaying)
            flowing = false;
    }
    
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Hand")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!flowing)
                {
                    audioSource.Play();
                    flowing = true;
                }
            }
        }
    }
    
}
