using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public Slider music, effects;
    public Button swipe, touch;

    private void Awake() 
    {    
        if (!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetFloat("Music", 1);

        if (!PlayerPrefs.HasKey("Effects"))
            PlayerPrefs.SetFloat("Effects", 1);

        if (!PlayerPrefs.HasKey("Points"))
            PlayerPrefs.SetInt("Points", 0);

        if (!PlayerPrefs.HasKey("Control"))
            PlayerPrefs.SetString("Control", "Swipe");
            
        music.value = PlayerPrefs.GetFloat("Music");
        effects.value = PlayerPrefs.GetFloat("Effects");
    }

    private void Update() 
    {
        SoundSettingsChange();
        ControlSettingsChange();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ControlChange(string controll)
    {
        PlayerPrefs.SetString("Control", controll);
    }

    private void ControlSettingsChange()
    {
        if(PlayerPrefs.GetString("Control") == "Swipe" && swipe.interactable)
        {
            swipe.interactable = false;
            touch.interactable = true;
        }
            
        if(PlayerPrefs.GetString("Control") == "Touch" && touch.interactable)
        {
            swipe.interactable = true;
            touch.interactable = false;
        }
    }

    private void SoundSettingsChange()
    { 
        if (music.value != PlayerPrefs.GetFloat("Music"))
            PlayerPrefs.SetFloat("Music", music.value);

        if (effects.value != PlayerPrefs.GetFloat("Effects"))
            PlayerPrefs.SetFloat("Effects", effects.value);
    }
}