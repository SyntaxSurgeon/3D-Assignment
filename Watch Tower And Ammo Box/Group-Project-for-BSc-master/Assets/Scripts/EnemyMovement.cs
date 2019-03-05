using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    Transform playerModel;
    CharacterController controller;

	// Use this for initialization
	void Start () {
        // The following lines ensure that the enemy assets target the player asset through
        // the use of a tag stating "Player", this makes it easier for the enemies to attack.
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        playerModel = playerGameObject.transform;
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (playerModel)
        {
            Vector3 direction = playerModel.position - transform.position;
            controller.Move(direction * Time.deltaTime);
        }
    }
}
