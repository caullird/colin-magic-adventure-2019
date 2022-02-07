using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chocked : MonoBehaviour
{
    public bool isChocked = false;
    public float timedChocked;
    private float timedChockedBase;
    // Start is called before the first frame update
    void Start()
    {
        timedChockedBase = timedChocked;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChocked)
        {
            timedChocked -= Time.deltaTime;
            if (timedChocked <= 0)
            {

                isChocked = false;
                timedChocked = timedChockedBase;
                transform.Rotate(0, 0, 0, Space.Self);
            }

            IsChocked();
            Debug.Log("ono");
        }
    }

    public void HasBeenChocked()
    {
        isChocked = true;
    }

    private void IsChocked()
    {
        transform.Rotate(0f, Random.Range(-2,2), 0.0f, Space.Self);
    }
}
