using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.Networking;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{


    public AudioMixer myAudioMixer;
    public AudioSource myAudioSource;
    public Slider Volume;

    public void StartGame()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("PlayGround");
        Time.timeScale = 1f;
        
    }
    public void ExitGame()
    {
        Debug.Log("S-a iesit din Program");
        Application.Quit();
    }
    
    public void SetVolume(float volume)
    {
        myAudioMixer.SetFloat("volume", volume);
        Debug.Log((volume+80)/100+"ss");
        myAudioSource.volume = (volume + 80)/100;

    }
    
}
