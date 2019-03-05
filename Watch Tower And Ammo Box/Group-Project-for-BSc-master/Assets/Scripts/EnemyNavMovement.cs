using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNavMovement : MonoBehaviour {

    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    
    // This script is an updated version of the EnemyMovement script, this script allows the enemy
    // to follow the player in a suitable manner and will ensure that the enemies stay on the ground.
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);
//        print(agent.remainingDistance);
        if (agent.remainingDistance < (agent.stoppingDistance + 0.5f))
        {
            transform.LookAt(target.transform);
        }
	}
}
