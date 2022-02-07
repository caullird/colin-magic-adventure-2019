using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    private float temps = 0;
    private bool run = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (run)
        {
            temps += Time.deltaTime;
            UpdateTemps();
        }
    }

    void UpdateTemps()
    {
        float minutes = temps / 60;
        float secondes = temps % 60;
        if(Mathf.Floor(secondes) < 10)
        {
            timer.text = Mathf.Floor(minutes) + " : 0" + Mathf.Floor(secondes);
        }
        else
        {
            timer.text = Mathf.Floor(minutes) + " : " + Mathf.Floor(secondes);
        }
    }

    public void Stop()
    {
        run = false;
    }
}
