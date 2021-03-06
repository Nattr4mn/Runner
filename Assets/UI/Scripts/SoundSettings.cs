using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public AudioSource music, effects;

    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("Music"); 
        effects.volume = PlayerPrefs.GetFloat("Effects");
    }

    void Update()
    {
        if (music.volume != PlayerPrefs.GetFloat("Music"))
            music.volume = PlayerPrefs.GetFloat("Music");

        if (effects.volume != PlayerPrefs.GetFloat("Effects"))
            effects.volume = PlayerPrefs.GetFloat("Effects");
    }
}
