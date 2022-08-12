using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] float turnSpeed = 5f;
    public Transform target;
    public float chaseRange = 5f;

    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    Vector3 directionToTarget;
    bool isProvoked = false;

    public LayerMask targetMask, ObstructionMask;
 

    

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        directionToTarget = (target.position-transform.position).normalized;
        
        Debug.DrawRay(transform.position, directionToTarget);
        RaycastHit hit;
        if (isProvoked)
        {
            EngageTarget();

        }
        else if (distanceToTarget <= chaseRange)
        {
            if (!Physics.Raycast(transform.position,directionToTarget,out hit,distanceToTarget,ObstructionMask))
                    isProvoked = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
        Handles.DrawLine(transform.position, target.position);
        
      
    }

    private void EngageTarget() 
    {
        faceTarget();

        if (navMeshAgent.stoppingDistance < distanceToTarget) 
        {
            chaseTarget();
        }

        if(navMeshAgent.stoppingDistance >= distanceToTarget)
        {
            attackTarget();
        }
    
    }

    public void AmIGetShoot() 
    {

        isProvoked = true;
    
    }

    private void chaseTarget() 
    {
       
             navMeshAgent.SetDestination(target.position);
    }
    private void attackTarget()
    {
       
       
    }

    private void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);
    }

   
}
