using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapChanger : MonoBehaviour
{
    public GameObject floor2;
    public GameObject floor1;
    private bool floor2Active = false;
    // Start is called before the first frame update
    void Start()
    {
        floor2.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "MinimapChecker")
        {
            if (!floor2Active)
            {
                floor2Active = true;
            }
            else
            {
                floor2Active = false;
            }
            floor2.SetActive(floor2Active);
        }
    }
}
