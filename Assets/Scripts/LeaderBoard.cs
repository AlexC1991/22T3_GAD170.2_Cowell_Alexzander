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
    private string healthPlant;
    private string namePlant;
    private string []greenHouse;
    private string fileName;
    private string fullPath;
    private bool calculateIt = false;
    private float maxNumber = 10;
    private float transferNumber;



    private void Update(){
        fileName = "Assets/GreenHouse.txt";
        fullPath = Path.GetFullPath(fileName);

    }
    private void SaveData()
    {
            using (StreamWriter greenHouse = new StreamWriter(fullPath, true)) { 
            greenHouse.WriteLine("|Plant Name: " + namePlant + "| |Plant Value: " + dollarPlant + "| |Plant Health: " + healthPlant + "|");
        }

    }
    public void LoadData()
    {
        string text = File.ReadAllText(fileName);

        printItOut.text = text.ToString();

        transferNumber = Convert.ToInt32(text);

        
        

        Debug.Log(transferNumber);
    }



    public void StartKey(){

            namePlant = plantInfo.returnArray;
            healthPlant = Convert.ToString(plantInfo.returnHealth);
            dollarPlant = Convert.ToString(plantInfo.returnPrice);
            SaveData();
    }

}
