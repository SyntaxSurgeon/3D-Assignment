using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{

    Animator anim;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    // This controls the amount of time until the enemy can attack again.
    float nextTimeAttackIsAllowed = -1.0f;

    // This controls the amount of time between each of the enemy's attacks.
    [SerializeField] float attackDelay = 1.0f;

    // This controls the amount of damage the enemy deals (This can be altered).
    [SerializeField] int damageDealt = 5;

    // The following lines control the enemy's ability to deal damage to the player and
    // will allow the player to lose health from their health bar.
    [SerializeField] GameObject bloodHit;

    [SerializeField] AudioSource AudioScr;

    private void AttackSound()
    {
        AudioScr.Play();
    }

    void OnTriggerStay(Collider other)
    {
        //print(Time.time>=nextTimeAttackIsAllowed);

        if (other.tag == "Player" && (Time.time >= nextTimeAttackIsAllowed))
        {

            Health playerHealth = other.GetComponent<Health>();
            anim.SetTrigger("Attack");
            playerHealth.Damage(damageDealt);

            Vector3 hitDirection = (transform.root.position - other.transform.position).normalized;
            Vector3 hitEffectPos = other.transform.position + (hitDirection * 0.01f) + (Vector3.up * 0.1f);
            Quaternion hitEffectRotation = Quaternion.FromToRotation(Vector3.forward, hitDirection);
            //Instantiate(bloodHit, hitEffectPos, hitEffectRotation);
            nextTimeAttackIsAllowed = Time.time + attackDelay;
        }
    }



    // Update is called once per frame
    void Update()
    {

    }
}