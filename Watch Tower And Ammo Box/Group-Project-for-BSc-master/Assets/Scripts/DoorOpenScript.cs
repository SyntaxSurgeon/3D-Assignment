using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenScript : MonoBehaviour
{

    // When the door is enabled, the door will be down and in it's original position
    void OnEnable()
    {
        this.transform.position =
            new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
    }
    
    // When the door is disabled, the door will rise up from it's position and the player will
    // be able to proceed to the next area.
    void OnDisable()
    {
        this.transform.position =
            new Vector3(transform.position.x, transform.position.y - 3, transform.position.z);
    }
}
