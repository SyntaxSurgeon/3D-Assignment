using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    
    // Each of these lines control a different part of the UI.
    public Health healthScript;
    public Text healthTxt;
    public Slider healthBar;
    public Text scoreNum;
    public static int score = 50;
   // public Text timeNum;
    //static int score;
    public GameObject losePanel;

    public GameObject winPanel;

    void Start()
    {
        // This section of the script imports to the GameManager and allows the UI to function effectively.
        healthScript = GetComponent<Health>();
        GameManager manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        healthBar = manager.playerHealth;
        healthTxt = manager.playerHealthTxt;
        scoreNum.text = score.ToString();
        //timeNum = manager.timeTxt;

        healthBar.maxValue = healthScript.getMaxHealth();
        healthBar.value = healthScript.getHealth();
        healthTxt.text = "Health: " + healthScript.getHealth();
        StartCoroutine("updateUI");

        winPanel.SetActive(false);
    }

   /** public static void updateScore(int amount)
    {
        score += amount;
    }**/
    //Update is called once per frame
    void Update()
    {
        {
            healthBar.value = healthScript.getHealth();
            healthTxt.text = "Health:" + healthScript.getHealth();
            //timeNum.text = "" + (int)timeNum.time;
            //scoreNum.text = score + "";

            scoreNum.text = score.ToString();
        }
    }
        IEnumerator updateUI()
        {
            healthBar.value = healthScript.getHealth();
            healthTxt.text = "Health: " + healthScript.getHealth();
            //timeNum.text = "" + (int)Time.time;
            //scoreNum.text = score + "";

            yield return new WaitForSeconds(0.5f);
            StartCoroutine("updateUI");
        }

    public void AddScore()
    {
        score += 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo") && shootingScriptV2.allRifleAmmo < 90)
        {
            shootingScriptV2.allRifleAmmo += 30;

            if (shootingScriptV2.allRifleAmmo > 90)
            {
                shootingScriptV2.allRifleAmmo = 90;
            }

            Destroy(other.gameObject);
        }

        if (other.CompareTag("Car"))
        {
            winPanel.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            gameObject.SetActive(false);
        }
    }
}