using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotScores : MonoBehaviour
{
    static public int score = 10;
    public int curLevel;
    public List<string> scores = new List<string>();
    void Awake(){
        if(PlayerPrefs.HasKey("HighScore__" + MissionDemolition.level)){
            score = PlayerPrefs.GetInt("HighScore__" + MissionDemolition.level);
            //scores[MissionDemolition.level] = "Best Score: " + score;
        }
        PlayerPrefs.SetInt("HighScore__" + MissionDemolition.level, score);
        
    }

    // Update is called once per frame
    void Update()
    {
        //print(MissionDemolition.level);
        //print(MissionDemolition.levelMax);
        Text gt = this.GetComponent<Text>();
        gt.text = "Best Score: " + score;
    
        if(score < PlayerPrefs.GetInt("HighScore__" + MissionDemolition.level)){
            PlayerPrefs.SetInt("HighScore__" + MissionDemolition.level, score);
        }
        
    }
}
