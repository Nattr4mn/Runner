using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Music"))
            PlayerPrefs.SetFloat("Music", 1);

        if (!PlayerPrefs.HasKey("Effects"))
            PlayerPrefs.SetFloat("Effects", 1);

        if (!PlayerPrefs.HasKey("Distance"))
            PlayerPrefs.SetInt("Distance", 0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}