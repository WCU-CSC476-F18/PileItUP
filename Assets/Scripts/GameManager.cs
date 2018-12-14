using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Set Dynamically")]
    private static int score;
    public Camera mainCamera;
    private int highScore;
    public Text highScoreText;

    // Use this for initialization
    void Start()
    {

        score = 0;
        //Set main camera and place it over tower base
        mainCamera = Camera.main;
        mainCamera.transform.position = new Vector3(3, 5, 3);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
        else
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScore = score;
        }

        highScoreText.text = "High Score: " + highScore.ToString();
    }

    public static int SCORE   
    {
        get
        {
            return (score);
        }
        set
        {
            score = value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) || Input.GetKeyDown(KeyCode.Space))
        {
            if (BuildTower.CurrentCube != null)
            {
                BuildTower.CurrentCube.Stop();
            }
            score += 1;
            FindObjectOfType<SpawnNewCube>().SpawnCube();

            if(score > highScore)
            {
                highScore = score-2;
                PlayerPrefs.SetInt("HighScore", highScore);
            }

            PlayerPrefs.SetInt("Score", score-2);
            //move camera up 
            mainCamera.transform.position += new Vector3(0f,.5f,0f);


            Debug.Log(score);
        }
    }
}
