using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        int finalShots = MissionDemolition.totalShots;
        Text gt = this.GetComponent<Text>();
        gt.text = "Total Shots Taken: " + finalShots + "\n";
        gt.text += "Previous best score: " + MissionDemolition.prevBest +"\n";
        if(finalShots < MissionDemolition.prevBest){
            gt.text += "You've set a new Best Score!\n";
            gt.text += "It took you " + (MissionDemolition.prevBest - finalShots) + " less shots to take down the castles!\n";
            gt.text += "New Best Score: " + finalShots;
        }else{
            gt.text += "Try again! You only missed the best score by " + (finalShots - ShotScores.score) + " shots!";
        }

    }
}
