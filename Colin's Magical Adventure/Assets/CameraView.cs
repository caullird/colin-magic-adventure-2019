using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    public GameObject normal;
    public GameObject front;
    public GameObject back;
    private int pos = 0;
    public float timer = 0.5f;
    private float timerBase;
    // Start is called before the first frame update
    void Start()
    {
        timerBase = timer;
        PlayerPrefs.SetInt("View", 0);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.F5))
        {
            if(timer <= 0)
            {
                timer = timerBase;
                pos++;
                if (pos > 2)
                    pos = 0;

                switch (pos)
                {
                    case 0:
                        normal.SetActive(true);
                        front.SetActive(false);
                        back.SetActive(false);
                        PlayerPrefs.SetInt("View", 0);
                        break;
                    case 1:
                        normal.SetActive(false);
                        front.SetActive(false);
                        back.SetActive(true);
                        PlayerPrefs.SetInt("View", 1);
                        break;
                    case 2:
                        normal.SetActive(false);
                        front.SetActive(true);
                        back.SetActive(false);
                        PlayerPrefs.SetInt("View", 2);
                        break;
                }

            }
        }
    }
}
