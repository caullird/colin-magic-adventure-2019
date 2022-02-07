using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsException : MonoBehaviour
{
    public List<GameObject> CollideException;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject g in CollideException)
        {
            Physics.IgnoreCollision(g.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
