using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookX : MonoBehaviour
{
    // This script controls the x axis of the player's camera, as well as how sensitive it is.
    [SerializeField] float sensitivity = 5.0f;

    void Start() { }

    //Update is called once per frame 
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
    }
}
