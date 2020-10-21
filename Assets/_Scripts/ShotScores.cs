using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotScores : MonoBehaviour
{
    static public int score = 21;
    void Awake(){
        if(PlayerPrefs.HasKey("ShotsTaken_")){
            score = PlayerPrefs.GetInt("ShotsTaken_");
        }
        PlayerPrefs.SetInt("ShotsTaken_", score);
        
    }

    // Update is called once per frame
    void Update()
    {

        Text gt = this.GetComponent<Text>();
        gt.text = "Best Score: " + score;
        if(score < PlayerPrefs.GetInt("ShotsTaken_")){
            PlayerPrefs.SetInt("ShotsTaken_", score);
        }
        
    }
}
