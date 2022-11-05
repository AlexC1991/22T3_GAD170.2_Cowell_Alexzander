using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;
using static UnityEngine.Rendering.DebugUI;
using Unity.VisualScripting;
using System.Diagnostics.CodeAnalysis;
using UnityEditor.Profiling.Memory.Experimental;
using static UnityEditor.PlayerSettings;
using JetBrains.Annotations;

namespace AlexzanderCowell { 
}

public class PlantDictionary : MonoBehaviour
{
    [SerializeField] GameManager gameManger;
    [SerializeField] LeaderBoard plantsLeader;
    [SerializeField] Text textWords;
    [HideInInspector]
    public string greenhouseTextFile;
    [HideInInspector]
    public string fileLines;
    [HideInInspector]
    public string text;
    [SerializeField] private string[] plantsL;
    //[SerializeField] List<string> plantL = new List<string>();
    private string plantLine;
    private string posPlant;
    private int posPlant2;
    private int index;

    public void Addit()
    {

        textWords.text = text.ToString();


    }

    public void PressedUpdate()
    {
        if (plantsLeader.buttonCounter == 10)
        {
            Debug.Log("Max Limit");
        }

        greenhouseTextFile = Application.streamingAssetsPath + "/GreenHouse" + ".txt";
        text = File.ReadAllText(greenhouseTextFile);
        plantsL = text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        //plantL.Add(text);
        plantLine = plantsLeader.healthPlant;
        index = GetComponent<PlantDictionary>().plantsL.Count();


    }
    private void Update()
    {


        if (index > 10)
        {
            RemoveIT();
        }
        
    }

    private void RemoveIT()
    {
      if (posPlant == "|Plant Health: 3|" + "|Plant Health: 2|" + "|Plant Health: 1|" + "|Plant Health: 4|")
        {
            posPlant = GetComponent<PlantDictionary>().plantsL.ToList().ToString();

            Debug.Log("Found It");
        }

    }
}

