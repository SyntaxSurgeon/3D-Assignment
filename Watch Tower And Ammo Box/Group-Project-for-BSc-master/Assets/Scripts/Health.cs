using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the amount of health the player asset will have and is scaled
// to a maximum of 100 health (Without health pick-ups).
public class Health : MonoBehaviour {

    [SerializeField] int maximumHealth = 100;
    public int currentHealth = 0;
    Animator anim;
    public Renderer renderer;

    public GameObject losePanel;

    void Start () {
        currentHealth = maximumHealth;
        anim=GetComponent<Animator>();
        renderer = GetComponentInChildren<Renderer>();
        losePanel.SetActive(false);
    }

    void Update()
    {
        if(IsDead&&!renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    

    public bool IsDead { get { return currentHealth <= 0; } }

    public int getHealth()
    {
        return currentHealth;
    }

    public int getMaxHealth()
    {
        return maximumHealth;
    }

    public void Damage(int damageValue)
    {
        currentHealth -= damageValue;

        if (currentHealth <= 0) {
            if (gameObject.tag != "Player")
            {
                SpawnScript.EnemyDie();

                UIScript.score += 100;
            
                if(anim)
                {
                    anim.SetBool("Dead", true);
                }
                //UIScript.updateScore(50);
                Destroy(GetComponent<EnemyNavMovement>());
                Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
                Destroy(GetComponent<CharacterController>());
                Destroy(GetComponentInChildren<EnemyAttack>());

                GameManager.amountkilled++;
            }
        
            else
            {
                Destroy(gameObject);

                losePanel.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                gameObject.SetActive(false);
            }
        }
    }

    public void AddHealth()
    {
        currentHealth += 30;

        if (currentHealth > 100)
        {
            currentHealth = 100;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health") && currentHealth < 100)
        {
            currentHealth += 40;

            if (currentHealth > 100)
            {
                currentHealth = 100;
            }

            Destroy(other.gameObject);
        }
    }
}