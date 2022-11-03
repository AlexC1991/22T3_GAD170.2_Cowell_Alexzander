using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;

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
    
    public void Addit(){ 
        greenhouseTextFile = Application.streamingAssetsPath + "/GreenHouse" + ".txt";


    text = File.ReadAllText(greenhouseTextFile);

        textWords.text = text.ToString();
    }

    public void PressedUpdate(){
        

        if (plantsLeader.buttonCounter == 10)
        {
            Debug.Log("Max Limit");
        }

        Debug.Log(plantsL);
    }

    private void Update(){
        plantsL = text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        if (plantsLeader.buttonCounter > 10)
        {
            Remove();
        }

    }

    private void Remove()
    {
        

    }


}

