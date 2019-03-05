using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnCollisionEnter works.");

        if (other.CompareTag("Ammo"))
        {
            Debug.Log("OnCollisionEnter works 2.");

            shootingScriptV2 shooting = GetComponent<shootingScriptV2>();

            shootingScriptV2.allRifleAmmo += 30;

            if(shootingScriptV2.allRifleAmmo > 90)
            {
                shootingScriptV2.allRifleAmmo = 90;
            }

            Destroy(other.gameObject);
        }
    }
}
