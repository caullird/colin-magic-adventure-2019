using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseHover : MonoBehaviour
{
    public void ChangeColorEnter()
    {
        Debug.Log(GetComponentInChildren<Text>().color);
        //new Color(147f, 1f, 1f, 1f);
        Text t = GetComponentInChildren<Text>();
        t.color = new Color32(0, 255, 0, 255);
        
    }

    public void ChangeColorExit()
    {
        Debug.Log("Bye");
        Text t = GetComponentInChildren<Text>();
        t.color = new Color32(255, 0, 0, 255);
    }
}
