using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour {

public GameObject target;

// Update is called once per frame
// This controls the position of the minimap of the screen.
void Update () 
{
	transform.position = new Vector3(target.transform.position.x,
	transform.position.y, target.transform.position.z);	
	
}
}
