using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController1 : MonoBehaviour
{

    Rigidbody2D rbBoss;
    Vector2 startPosition;
    public float roamRadius;
    //private NavMeshAgent navAgent;

    void Start()
    {
        rbBoss = GetComponent<Rigidbody2D>();
        //navAgent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        InvokeRepeating("randomBossMovement", 10.0f, 10.0f);

    }
    
    void FixedUpdate()
    {
        
    }

    public void randomBossMovement() {

        Vector2 randomMovement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rbBoss.AddForce(randomMovement*roamRadius);
        /*
        Vector2 randomDirection = Random.insideUnitSphere;
        Debug.Log(randomDirection);
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, roamRadius, 1);
        Vector2 finalPosition = new Vector2(hit.position.x, hit.position.y);
        //navAgent.destination = finalPosition;
        */


    }
}
