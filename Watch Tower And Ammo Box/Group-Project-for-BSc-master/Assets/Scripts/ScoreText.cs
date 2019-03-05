using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int scoreT;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        scoreT = UIScript.score;

        scoreText.text = "Score: " + scoreT.ToString();
	}
}
