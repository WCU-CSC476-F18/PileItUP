using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Text gt = this.GetComponent<Text>();
        int score = GameManager.SCORE;

        if(score <= 1)
        {
            gt.text = "Score: 0";
        }
        else
        {
            gt.text = "Score: " + (score - 1).ToString();
        }
    }
}
