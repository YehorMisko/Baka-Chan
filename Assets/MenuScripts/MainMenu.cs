using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;


public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public TMPro.TMP_Dropdown  resolutionDropdown;
    public GameObject menu;
    public GameObject options;
    int currentResolutionIndex = 0;
    void Start()
    {   //Add all resolutions
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();
        //Remove the default drop down options
        resolutionDropdown.ClearOptions();
        //Make a list of all resolutions options
        List<string> options = new List<string>();
        for (int i = 0;i < resolutions.Length;i++)
        {
          
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
           

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        //Add the list to the drop down
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    //Starts the game
    public void NewGameButton()
    {
        SceneManager.LoadScene(1);
    }
    //Quits the game
    public void QuitGame()
    {
        Application.Quit();
    }

    //Changes the volume based on the slider
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        
    }
    //Fullscreen control
    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    //Switch the resolution to the one that got chosen
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }
    //Goes back from options to main menu
    public void BackMenu()
    {
        options.SetActive(false);
        menu.SetActive(true);   
    }
    //Goes from main menu to options
    public void OptionsMenu()
    {
        menu.SetActive(false);
        options.SetActive(true);
    }
}
