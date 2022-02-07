using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour
{
    public LayerMask LayerMask;
    public AudioSource AttackSound;
    public float radius;
    private bool launched = false;
    private bool canBeLaunch = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canBeLaunch)
        {
            AttackSound.Play();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, LayerMask);
            foreach(Collider c in hitColliders)
            {
                c.gameObject.GetComponent<Chocked>().HasBeenChocked();                
            }
            launched = true;
            canBeLaunch = false;
        }
    }

    public bool isLaunch()
    {
        return launched;
    }

    public void setCanBeLaunch()
    {
        launched = false;
        canBeLaunch = true;
    }

    
}
