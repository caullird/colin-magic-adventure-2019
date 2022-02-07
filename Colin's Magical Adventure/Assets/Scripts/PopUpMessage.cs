using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{

    public GameObject MessageContainer;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = MessageContainer.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Door")
        {
            text.text = "Press E to open door";
        }

        if (other.gameObject.tag == "SheetsContainers")
        {
            text.text = "Press E to put sheets on the table";
        }

        if (other.gameObject.tag == "Sheets")
        {
            text.text = "Press E to inspect";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Door")
        {
            text.text = "Press E to open door";
        }

        if (other.gameObject.tag == "Sheets")
        {
            text.text = "Press E to inspect";
        }

        if (other.gameObject.tag == "SheetsContainers")
        {
            text.text = "Press E to put sheets on the table";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        text.text = "";
    }
}
