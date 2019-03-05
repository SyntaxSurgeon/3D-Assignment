using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject camera1;
    public GameObject camera2;

	// Use this for initialization
    // The following 2 lines control the cameras and set them to active or inactive
	void Start () {
        camera1.SetActive(true);
        camera2.SetActive(false);
	}
	
	// Update is called once per frame
    // If the player moves in to the path of the raycast, the camera's will switch from 
    // a third-person view to a birds-eye view.
	void FixedUpdate () {
        Debug.DrawRay(transform.position, (transform.position + (new Vector3(10, 0, 0))), Color.red);
        if (Physics.Raycast(transform.position, transform.right, 10))
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
        }
        else
        {
            camera2.SetActive(false);
            camera1.SetActive(true);
        }
		
	}
}
