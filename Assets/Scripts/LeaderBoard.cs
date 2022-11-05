using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;



public class LeaderBoard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlantsList plantInfo;
    [SerializeField] Text printItOut;
    [HideInInspector]
    public string plantName;
    [HideInInspector]
    public float plantValue;
    [HideInInspector]
    public float plantHealth;

    private string dollarPlant;
    [HideInInspector]
    public string healthPlant;
    public string namePlant;
    [HideInInspector]
    public string fileName;
    [HideInInspector]
    public string fullPath;
    [HideInInspector]
    public float transferNumber;
    [HideInInspector]
    public int buttonCounter;



    private void Update(){
        fileName = "Assets/StreamingAssets/GreenHouse.txt";
        fullPath = Path.GetFullPath(fileName);

    }
    private void SaveData()
    {
        buttonCounter += 1;

            using (StreamWriter greenHouse = new StreamWriter(fullPath, true)) { 
            greenHouse.WriteLine("|Plant Name: " + namePlant + "| |Plant Value: " + dollarPlant + "| |Plant Health: " + healthPlant + "|");
        }

    }
    public void StartKey(){

            namePlant = plantInfo.returnArray;
            healthPlant = Convert.ToString(plantInfo.returnHealth);
            dollarPlant = Convert.ToString(plantInfo.returnPrice);
            SaveData();
    }

}
