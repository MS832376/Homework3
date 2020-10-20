﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotScores : MonoBehaviour
{
    static public int score = 10;
    void Awake(){
        if(PlayerPrefs.HasKey("HighScore")){
            score = PlayerPrefs.GetInt("HighScore");
        }
        PlayerPrefs.SetInt("HighScore",score);
    }

    // Update is called once per frame
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "Fewest Shots: " + score;
        if(score < PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
}