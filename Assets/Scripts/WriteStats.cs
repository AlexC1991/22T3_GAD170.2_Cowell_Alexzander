using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor.ShaderGraph.Serialization;


public class WriteStats : MonoBehaviour
{
    // Start is called before the first frame update
    PlantsList plantInfo;
    [HideInInspector]
    public string plantName;
    [HideInInspector]
    public float plantValue;
    [HideInInspector]
    public float plantHealth;

    private float dollarPlant;
    private float healthPlant;
    private string namePlant;

    void SaveData(){
        

        List <string> namePlant = new List<string>();
        namePlant.Add("Plant Name " + plantName);

        List<string> dollarPlant = new List<string>();
        dollarPlant.Add("Plant Value " + plantValue);

        List<string> healthPlant = new List<string>();
        healthPlant.Add("Plant Health " + plantHealth);

        string path = Application.persistentDataPath + "/GreenHouse.Save";
        File.WriteAllText(path, namePlant.ToString());
        File.WriteAllText(path, dollarPlant.ToString());
        File.WriteAllText(path, healthPlant.ToString());

    }

    void LoadDate(){

    }

    public void StartKey()
    {

        namePlant = plantInfo.returnArray;
        healthPlant = plantInfo.returnHealth;
        dollarPlant = plantInfo.returnPrice;

        SaveData();
        
    }

}
