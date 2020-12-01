using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text uiText;
    public float mainTimer;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = mainTimer;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer>1.0f)
        {
            timer -= Time.deltaTime;
            float min = Mathf.Floor(timer / 60);
            string sec;
           sec = (timer % 60 ).ToString("f0");
            if (timer % 60 - 9 < 0)
            {
                sec = "0" + (timer % 60).ToString("f0");
                
            }
            if (timer < 10) {
                sec = "0" + (timer % 60 - 1).ToString("f0");
                uiText.color = Color.red;
                uiText.fontSize = 20;
            }
                uiText.text = min + ":" + sec;
        }
        else
        {
            SceneManager.LoadScene("Result");
            Debug.Log("timpul s-a scurs");
            timer = 0;
            


        }
    }
}
