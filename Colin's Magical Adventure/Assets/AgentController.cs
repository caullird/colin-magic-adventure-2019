using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Chocked chocked;
    public Transform target;
    private Animator anim;
    public LayerMask layer;
    
    // Start is called before the first frame update
    void Start()
    {
        chocked = GetComponent<Chocked>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
        Collider[] hit = Physics.OverlapSphere(transform.position, 5, layer);
        if(hit.Length != 0)
        {
            if (!chocked.isChocked)
            {
                agent.isStopped = false;
                Vector3 pos = target.position;
                agent.SetDestination(pos);
                anim.SetBool("isRunning", true);
            }

        }
        else
        {
            agent.isStopped = true;
            anim.SetBool("isRunning", false);
        }

        if (!chocked.isChocked)
        {
            anim.SetBool("isChocked", false);

        }
        else
        {
            anim.SetBool("isChocked", true);
            anim.SetBool("isRunning", false);
            agent.isStopped = true;
        }
        

        
    }

    
}
