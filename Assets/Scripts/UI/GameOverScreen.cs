using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public PointsSystem distance;

    public void LoadLevel(int lvl)
    {
        Time.timeScale = 1f;
        SaveDistance();
        SceneManager.LoadScene(lvl);
    }

    private void SaveDistance()
    {
        if (PlayerPrefs.GetInt("Distance") < distance.distance)
        {
            PlayerPrefs.SetInt("Distance", distance.distance);
        }
    }
}
