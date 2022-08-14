using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArcherAttackAI : MonoBehaviour
{
    EnemyAI MainAI;
    bool alreadyAttacked = false;
    float timeBetweenAttacks = 2f;
    public GameObject projectTile;
    


    private void Start()
    {
        MainAI = GetComponent<EnemyAI>();
    }
    public void AttackPlayer()
    {

        MainAI.navMeshAgent.SetDestination(transform.position);
        transform.LookAt(MainAI.target);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectTile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

}
