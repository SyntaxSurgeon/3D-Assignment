using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WayPoints : MonoBehaviour {

    NavMeshAgent agent;
    // List or Array of points- starts at number 0
    public GameObject waypoints;
    Transform[] points;
    public int destPoint = 0;

    public static int Length { get; internal set; }

    // Use this for initialization
    void Start () {
        points = waypoints.GetComponentsInChildren<Transform>();
        agent = GetComponent<NavMeshAgent>();
        // Can turn off autobraking to not stop between waypoints
        agent.autoBraking = false;
        GotoNextPoint();
	}
	
    void GotoNextPoint()
    {
        if (points.Length == 0) {
            return;      }

        agent.SetDestination(points [destPoint].position);
        // If goes higher than the total number of waypoints -> go back to start of array
        destPoint = (destPoint + 1) % points.Length;
    }

	// Update is called once per frame
	void Update () {
		if (agent.remainingDistance < 0.5f) {
            GotoNextPoint();
        }
	}
}
