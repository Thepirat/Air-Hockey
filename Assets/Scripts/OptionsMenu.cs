using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;


public class OptionsMenu : MonoBehaviour {

    List<string> resolutions = new List<string>();
    List<string> screenmodes = new List<string>() { "FullScreen", "Windowed" };
    public Dropdown ResolutionDropDown;
    public Dropdown ScreenModeDropDown;
    public Dropdown ScreenResolutions;
    public AudioSource MyAudioSource;
    public AudioMixer myAudioMixer;
    public Slider VolumeSlider;
    Resolution[] resolution;



    private void Start()
    {
        Populate();
    }

    public void Apply()
    {
        if (ScreenModeDropDown.options[ScreenModeDropDown.value].text == "FullScreen")
            SettingResolution(ResolutionDropDown.value, true);
        else SettingResolution(ResolutionDropDown.value, false);

        //Screen.SetResolution(x, y, true);
        /*
        if (ScreenModeDropDown.options[ScreenModeDropDown.value].text == "FullScreen")
        {
            if (ResolutionDropDown.options[ResolutionDropDown.value].text == "800x600")
            {
                Screen.SetResolution(800, 600, true);
                Debug.Log("800x600 fullscreen");
            }
            else if (ResolutionDropDown.options[ResolutionDropDown.value].text == "1280x1024")
            {
                Screen.SetResolution(1280, 1024, true);
                Debug.Log("1280x1024 fullscreen");
            }
            else if (ResolutionDropDown.options[ResolutionDropDown.value].text == "1360x768") Screen.SetResolution(1360, 768, true);
            else if (ResolutionDropDown.options[ResolutionDropDown.value].text == "1600x900") Screen.SetResolution(1600, 900, true);
            else if (ResolutionDropDown.options[ResolutionDropDown.value].text == "1920x1080") Screen.SetResolution(1920, 1080, true);
            else Debug.Log("Selectati rezolutia");
        }
        if (ScreenModeDropDown.options[ScreenModeDropDown.value].text == "Windowed")
        {
            if (ResolutionDropDown.options[ResolutionDropDown.value].text == "800x600")
            {
                Screen.SetResolution(800, 600, false);
                Debug.Log("800x600 windowed");
            }
            else if (ResolutionDropDown.options[ResolutionDropDown.value].text == "1280x1024")
            {
                Screen.SetResolution(1280, 1024, false);
                Debug.Log("1280x1024 windowed");
            }
            else if (ResolutionDropDown.options[ResolutionDropDown.value].text == "1360x768") Screen.SetResolution(1360, 768, false);
            else if (ResolutionDropDown.options[ResolutionDropDown.value].text == "1600x900") Screen.SetResolution(1600, 900, false);
            else if (ResolutionDropDown.options[ResolutionDropDown.value].text == "1920x1080") Screen.SetResolution(1920, 1080, false);
            else Debug.Log("Selectati rezolutia");

            
        }
        */
        MyAudioSource.volume = (VolumeSlider.value + 80)/100;
        // Debug.Log(VolumeSlider.value);

    }
    void Populate()
    {
        resolution = Screen.resolutions;
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolution.Length; i++)
        {
            string res = resolution[i].width.ToString() + 'x' + resolution[i].height.ToString();
            resolutions.Add(res);
            
        }
        Debug.Log(currentResolutionIndex);
        ResolutionDropDown.AddOptions(resolutions);
        ScreenModeDropDown.AddOptions(screenmodes);
    }
    public void SettingResolution(int resolutionIndex,bool fullscreen)
    {
        Resolution setresolution = resolution[resolutionIndex];
        Debug.Log(resolution[resolutionIndex]);
        Screen.SetResolution(setresolution.width, setresolution.height, fullscreen);
        
        
    }

    public void SetVolume(float volume)
    {
       // Debug.Log(volume);
        myAudioMixer.SetFloat("volume", volume);
    }

    public void back ()
    {
       // ResolutionDropDown.ClearOptions();
        //ScreenModeDropDown.ClearOptions();
       // Populate();
    }
}
