using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Player player;
    public Text pointsCountText;
    public GameObject gameOverScreen;

    private void Update() 
    {
        GameOver();
        pointsCountText.text = player.points.ToString();
    }

    public void Pause() { Time.timeScale = 0f; }
    public void Continue() { Time.timeScale = 1f; }

    public void LoadLevel(int lvl)
    {
        Continue();
        SceneManager.LoadScene(lvl);
    }

    private void GameOver()
    {
        if(player.life == false)
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            gameOverScreen.SetActive(true);
            SavePoints();
        }
    }

    private void SavePoints()
    {
        if (PlayerPrefs.GetInt("Points") < player.points)
        {
            PlayerPrefs.SetInt("Points", player.points);
        }
    }

}
