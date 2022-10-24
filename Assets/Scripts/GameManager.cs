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
    [SerializeField] PlantsList plantList;
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] SceneLoader sceneLoader;

    private int roundClickMax = 20;
    private int roundClickMin = 0;


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

    public void GreenHouseLog()
    {
        string path = Application.dataPath + "/Greenhouse.txt";
        if (File.Exists(path))
        {
            File.WriteAllText(path, "Plant Name \n\n");
        }
        string content = "Plant Name " + plantList.returnArray + "/n";

        File.AppendAllText(path, content);
    }

}
