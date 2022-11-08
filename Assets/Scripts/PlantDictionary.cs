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
    [SerializeField] List<PlantsClass> _plantArray = new List<PlantsClass>();
    [SerializeField] List<PlantLoggingClass> newPlantList = new List<PlantLoggingClass>();
    [SerializeField] string[] outputHealthness;
    private int returnPrice;
    private int returnHealth;
    private string returnPlantName;
    private string fileName;
    private string fullPath;
    [SerializeField] private Text plantCaller;
    [SerializeField] private Text plantPrinter;
    protected void Update(){
        fileName = "Assets/StreamingAssets/GreenHouse.txt";
        fullPath = Path.GetFullPath(fileName);
        StartNames();
    }
    private void StartNames(){       
        _plantArray.Add(new PlantsClass("Sunflower", 10, 6));
        _plantArray.Add(new PlantsClass("Rose Bud", 5, 8));
        _plantArray.Add(new PlantsClass("White Rose", 8, 4));
        _plantArray.Add(new PlantsClass("Gold Rose", 5, 9));
        _plantArray.Add(new PlantsClass("Red Hornett", 8, 5));
        _plantArray.Add(new PlantsClass("Lotus Leaf", 3, 7));
        _plantArray.Add(new PlantsClass("Water Lilly", 1, 4));
        _plantArray.Add(new PlantsClass("Daisy", 4, 8));
        _plantArray.Add(new PlantsClass("PrimRose", 7, 9));
        _plantArray.Add(new PlantsClass("Jasmine", 9, 2));
        _plantArray.Add(new PlantsClass("Delilah", 10, 10));
        _plantArray.Add(new PlantsClass("Poppy", 2, 3));
        _plantArray.Add(new PlantsClass("Daffodils", 4, 1));
        _plantArray.Add(new PlantsClass("Iris", 5, 4));
        _plantArray.Add(new PlantsClass("Blue Bell", 3, 3));
        _plantArray.Add(new PlantsClass("Tiger Lilly", 6, 6));
        _plantArray.Add(new PlantsClass("Tulp", 2, 8));
        _plantArray.Add(new PlantsClass("Sweet Violet", 6, 3));
        _plantArray.Add(new PlantsClass("China Rose", 9, 2));
        _plantArray.Add(new PlantsClass("Periwinkle", 2, 8));
        _plantArray.Add(new PlantsClass("Buttercup", 2, 6));
        _plantArray.Add(new PlantsClass("Mary Gold", 5, 9));
        _plantArray.Add(new PlantsClass("Snow Drop", 1, 3));
        _plantArray.Add(new PlantsClass("Lotus", 1, 2));
        _plantArray.Add(new PlantsClass("Camellia", 8, 7));
        _plantArray.Add(new PlantsClass("Cactus Flower", 3, 4));
        _plantArray.Add(new PlantsClass("Hyacinth", 1, 8));
        _plantArray.Add(new PlantsClass("Pansy", 9, 9));
        _plantArray.Add(new PlantsClass("Narcissus", 8, 6));
        _plantArray.Add(new PlantsClass("Carnation", 5, 3));
        _plantArray.Add(new PlantsClass("Cyclamen", 3, 2));
        _plantArray.Add(new PlantsClass("Angel Pedal", 4, 6));
        
        ListOutCome();        
    }
    private void ListOutCome()
    {
        
    }            
       public void PlantToStart(){
        returnPlantName = (_plantArray[UnityEngine.Random.Range(0, _plantArray.Count())].plantD);
        returnPrice = (_plantArray[UnityEngine.Random.Range(0, _plantArray.Count())].maxPrice);
        returnHealth = (_plantArray[UnityEngine.Random.Range(0, _plantArray.Count())].maxHealth);
        plantCaller.text = "You found a " + returnPlantName + ", this flower is worth $" + returnPrice + " and the health of this flower is " + returnHealth + "/10. Do you want to keep it or reject it?".ToString();       
       }

    public void PlantListSave()
    {
        plantPrinter.text = ("|Plant Name: " + returnPlantName + "| |Plant Value: " + returnPrice + "| |Plant Health: " + returnHealth + "|").ToString();
        newPlantList.Add(new PlantLoggingClass("|Plant Name: " + returnPlantName + "| |Plant Value: " , returnPrice ,"| |Plant Health: " , returnHealth , "|"));      
        using (StreamWriter greenHouse = new StreamWriter(fullPath, true))
        {
            greenHouse.WriteLine(newPlantList);
        }
        Debug.Log(plantPrinter.text);
        if (newPlantList.Count() == 10)
        {

        }
    }
        public void PlantGreenHouseReader()
        {
         
        }
}



