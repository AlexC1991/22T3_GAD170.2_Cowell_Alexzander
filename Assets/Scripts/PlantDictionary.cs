using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Linq;
using UnityEditor;

namespace AlexzanderCowell
{


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
        [SerializeField] Plant plantPrefab;
        [SerializeField] List<Plant> plantList = new List<Plant>();
        [SerializeField] List<string> _plantNames = new List<string>();
        [SerializeField] Plant currentPlant;
        [SerializeField] private Text plantCaller;
        [SerializeField] private Text plantPrinter;
        protected void Awake()
        {
            _plantNames.Add("Rose");
            _plantNames.Add("Delilah");
            _plantNames.Add("Sunflower");
            _plantNames.Add("Rose Bud");
            _plantNames.Add("White Rose");
            _plantNames.Add("Gold Rose");
            _plantNames.Add("Red Hornett");
            _plantNames.Add("Lotus Leaf");
            _plantNames.Add("Water Lilly");
            _plantNames.Add("Daisy");
            _plantNames.Add("PrimRose");
            _plantNames.Add("Jasmine");
            _plantNames.Add("Poppy");
            _plantNames.Add("Daffodils");
            _plantNames.Add("Iris");
            _plantNames.Add("Blue Bell");
            _plantNames.Add("Tiger Lilly");
            _plantNames.Add("Tulp");
            _plantNames.Add("Sweet Violet");
            _plantNames.Add("China Rose");
            _plantNames.Add("Periwinkle");
            _plantNames.Add("Buttercup");
            _plantNames.Add("Lotus");
            _plantNames.Add("Pansy");
            _plantNames.Add("Carnation");
            _plantNames.Add("Camellia");
            _plantNames.Add("Cyclamen");
            _plantNames.Add("Angel Pedal");
    } // Plant Names Storage



        private void Start(){       
            Plant newPlant = Instantiate(plantPrefab, transform); 
            newPlant.plantName = _plantNames[UnityEngine.Random.Range(0, _plantNames.Count())];
            newPlant.maxHealth = UnityEngine.Random.Range(1, 11);
            newPlant.maxPrice = UnityEngine.Random.Range(1, 13);
            currentPlant = newPlant;
            plantCaller.text = "You found a " + currentPlant.plantName + ", this flower is worth $" + currentPlant.maxPrice + " and the health of this flower is " + currentPlant.maxHealth + "/10. Do you want to keep it or reject it?".ToString();
        } // Starting Script for the Game for Game text & Random Plant Names, Plant Price & Plant Health to Populate.
        public void StartPlanting(){ 
            Plant newPlant = Instantiate(plantPrefab,transform); // Do not spawn every frame only when i press the button.
            newPlant.plantName = _plantNames[UnityEngine.Random.Range(0, _plantNames.Count())]; 
            newPlant.maxHealth = UnityEngine.Random.Range(1, 11);
            newPlant.maxPrice = UnityEngine.Random.Range(1, 13);
            currentPlant = newPlant;
            plantCaller.text = "You found a " + currentPlant.plantName + ", this flower is worth $" + currentPlant.maxPrice + " and the health of this flower is " + currentPlant.maxHealth + "/10. Do you want to keep it or reject it?".ToString();               
        } // Button to keep Populating the Text UI.

        public void AddNewPlant()
        {
            plantList.Add(currentPlant);
        } // Adds the current plant i choose to keep and puts it into a plantList.
        public void PlantListSave()
        {
            foreach ( Plant plant in plantList)
            {
                plantPrinter.text = ("|Plant Name: " + plant.plantName + "| |Plant Price: " + plant.maxPrice + "| |Plant Health: " + plant.maxHealth + "|" + "\n").ToString();                
            }
        }
        private void PlantGreenHouseReader()
        {
            foreach ( Plant plant in plantList)
            {
                if (plant.plantName.Count() == 10)
                {
                    Debug.Log("Max Plants");
                }
            }
        }
    }
}



