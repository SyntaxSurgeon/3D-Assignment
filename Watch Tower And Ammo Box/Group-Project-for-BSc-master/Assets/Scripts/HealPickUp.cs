using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HealPickUp : MonoBehaviour
{
    // If player tag collides with health pick up, the pick up will be destroyed
    // and the player will gain 50 health (hence (-50)).
    void OnTriggerEnter(Collider collider)
    {
        print("pick up");
        if (collider.CompareTag("Player"))
        {

            Health health = collider.GetComponent<Health>();
            if (health!= null)
            {
                health.Damage(-50);
                Destroy(gameObject);
            }
        }
    }

}    
