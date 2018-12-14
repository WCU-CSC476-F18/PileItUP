using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Play_Scene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start_Scene");
    }
}