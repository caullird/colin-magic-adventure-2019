using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public SpecialAttack specialAttack;
    private bool launched;
    public float timer = 10f;
    private float timerBase;
    private Slider slider;
    private bool isRunning = false;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        timerBase = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (specialAttack.isLaunch() && !isRunning)
        {
            isRunning = true;
        }
        else
        {
            slider.value = 100;
        }
        if (isRunning)
        {
            if (timer <= 0)
            {
                specialAttack.setCanBeLaunch();
                timer = timerBase;
                isRunning = false;
                slider.value = 100;
            }
            else
            {
                slider.value = 100 - (timer / timerBase) * 100;
                timer -= Time.deltaTime;
            }
            
        }
    }
}
