using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace AlexzanderCowell
{

}
public class GameManager : MonoBehaviour{

    [SerializeField] Text roundCounter;
    [SerializeField] PlantDictionary plantDict;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] SceneLoader sceneLoader;
    /// Round count down clock
    private int roundClickMax = 20;
    private int roundClickMin = 0;
    
    /// Timer for start
    private int startTimer = 3;
    private int variableTime = 1;
    private int endTimer = 0;
    private bool finishedTimer;

   private void FixedUpdate(){
        startTimer -= variableTime;
        if (startTimer == 3){
            finishedTimer = false;
        }
        if (startTimer == endTimer){
            finishedTimer = true;
            plantDict.PlantToStart();            
        }

        if (finishedTimer == true){
            Time.timeScale = 0;
        }
        Debug.Log(startTimer);
    }




    public void RoundCountDown()
    {
        roundClickMax -= (1);

        roundCounter.text = "Rounds: " + roundClickMax.ToString();

        if (roundClickMax == (1))
        {
            Debug.Log("Final Flower!");
        }


        if (roundClickMax == roundClickMin)
        {
            sceneLoader.Leaderboard();
        }

    }

}
