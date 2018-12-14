using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndScene : MonoBehaviour {

    public Text highScoreText;
    public Text scoreText;
    public int score;
    public int highScore;


	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        highScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score: " + highScore.ToString();
        scoreText.text = "Score: " + score.ToString();


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
