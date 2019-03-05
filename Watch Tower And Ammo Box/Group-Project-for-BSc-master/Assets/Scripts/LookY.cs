using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookY : MonoBehaviour {

    // This script controls the y axis of the player's camera, as well as how sensitive it is.
    [SerializeField] float sensitivityY;
    public float minimumY = -30F;
    public float maximumY = 30f;
    float rotationY = 0f;

    void Start () { }
	
	// Update is called once per frame
	void Update () {
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		
	}
}
