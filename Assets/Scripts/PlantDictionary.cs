
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace AlexzanderCowell
{


    public class PlantDictionary : MonoBehaviour
    {
        [HideInInspector]
        GameManager gameManager;
        [SerializeField] SceneLoader sceneLoader;
        private float healthCalculate; // Takes the maxHealth of all the plants in the saved list.
        private float priceCalculate; // Takes the maxPrice of all plants in the saved list.
        [HideInInspector]
        public float totalHealth = 0; // Total health to be carried over to the leaderboard.
        [HideInInspector]
        public float totalPrice = 0; // Total price to be carried over to the leaderboard.
        [SerializeField] private Plant plantPrefab; // The prefab that will generate in game.
        [SerializeField] public List<Plant> plantList = new List<Plant>(); // List of all the saved details
        [SerializeField] private List<string> _plantNames = new List<string>(); // List of all the plant names, prices & health values.
        private Plant currentPlant; // Replaces _plantNames for the new data stored.
        [HideInInspector]
        [SerializeField] private Text plantCaller; // Prints the random string in the game.
        [HideInInspector]
        [SerializeField] private Text plantPrinter; // Prints the saved list
        [SerializeField] FloatSO storedData;
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
            newPlant.plantName = _plantNames[Random.Range(0, _plantNames.Count())];
            newPlant.maxHealth = Random.Range(1, 11);
            newPlant.maxPrice = Random.Range(1, 13);
            currentPlant = newPlant;
            plantCaller.text = "You found a " + currentPlant.plantName + ", this flower is worth $" + currentPlant.maxPrice + " and the health of this flower is " + currentPlant.maxHealth + "/10. Do you want to keep it or reject it?".ToString();
            
        } // Starting Script for the Game for Game text & Random Plant Names, Plant Price & Plant Health to Populate.
        public void StartPlanting(){ 
            Plant newPlant = Instantiate(plantPrefab,transform); // Do not spawn every frame only when i press the button.
            newPlant.plantName = _plantNames[Random.Range(0, _plantNames.Count())]; 
            newPlant.maxHealth = Random.Range(1, 11);
            newPlant.maxPrice = Random.Range(1, 13);
            currentPlant = newPlant;
            plantCaller.text = "You found a " + currentPlant.plantName + ", this flower is worth $" + currentPlant.maxPrice + " and the health of this flower is " + currentPlant.maxHealth + "/10. Do you want to keep it or reject it?".ToString();
           
        } // Button to keep Populating the Text UI.

        public void AddNewPlant(){
            plantList.Add(currentPlant);
            healthCalculate = currentPlant.maxHealth;
            priceCalculate = currentPlant.maxPrice;
            if (plantList.Count() == 11){               
                plantList.RemoveAt(0);
                Debug.Log("Destroy");
            }
        }// Adds the current plant i choose to keep and puts it into a plantList.
        public void PlantListSave(){
            foreach (Plant plant in plantList){
                
               plantPrinter.text = plantPrinter.text += ("|Plant Name: " + plant.plantName + "| |Plant Price: " + plant.maxPrice + "| |Plant Health: " + plant.maxHealth + "|" + "\n").ToString();    
                               
            }

        } // Adds the saved plant list to the UI Greenhouse text box.




        public void PlantListMinus(){
            foreach (Plant plant in plantList){
                plantPrinter.text = ("").ToString();
            }
        } // Removes the text from the UI Greenhouse text box

        private void Update(){
            foreach (Plant plant in plantList.ToList()){
                plantList = plantList.OrderBy(o => o.maxHealth).ToList();
                
            }
        } // Updates the saved list every frame with sorting the health by ascending order.
        public void EndOfRounds(){                       
                foreach (Plant plant in plantList.ToList()){                   
                    healthCalculate = plant.maxHealth;
                    priceCalculate = plant.maxPrice;
                    totalHealth += healthCalculate;
                    totalPrice += priceCalculate;
                    storedData.Health = totalHealth;
                    storedData.Price = totalPrice;
                }                      
            Debug.Log(" Total Price " + totalPrice + " Total Health " + totalHealth);
            
        } // Calculates the total health and price of the plants kept for the leaderboard.

    }

}



