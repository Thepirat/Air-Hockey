using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    public Text Resulttxt;
   // public GameObject MainMenu;
   // public GameObject Exit;

    public void Start()
    {
        // if()
        if (Score.PlayerScore > Score.AIScore) Resulttxt.text = "You Win!";
        else if (Score.PlayerScore < Score.AIScore) Resulttxt.text = "You Lose!";
        else Resulttxt.text = "That's A Draw Brow";

    }

    public void changeScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("S-a iesit din program");
    }
   // public void ResultText()
}
