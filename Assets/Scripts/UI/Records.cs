using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Records : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("Distance") > 0)
        {
            gameObject.SetActive(true);
            transform.GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("Distance").ToString();
        }
    }
}
