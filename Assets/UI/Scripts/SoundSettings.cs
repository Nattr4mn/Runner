using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    public Slider music, effects;

    void Start()
    {
        music.value = PlayerPrefs.GetFloat("Music");
        effects.value = PlayerPrefs.GetFloat("Effects");
    }

    // Update is called once per frame
    void Update()
    {
        if (music.value != PlayerPrefs.GetFloat("Music"))
            PlayerPrefs.SetFloat("Music", music.value);

        if (effects.value != PlayerPrefs.GetFloat("Effects"))
            PlayerPrefs.SetFloat("Effects", effects.value);
    }
}
