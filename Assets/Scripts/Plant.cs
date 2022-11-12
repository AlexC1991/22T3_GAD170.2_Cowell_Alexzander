
using UnityEngine;


namespace AlexzanderCowell
{


    public class Plant : MonoBehaviour{
        // Plant Names in the List //
        [HideInInspector]
        public string plantName;

        // Max Price & Health Range for Plants in the List //
        [HideInInspector]
        public int maxPrice;
        [HideInInspector]
        public int maxHealth;

        // Plant names / price / health for the list
        public Plant(string newPlantName, int newPrice, int newHealth)
        {
            plantName = newPlantName;
            maxPrice = newPrice;
            maxHealth = newHealth;
        }

    } // Holds all the saved Data for the plants that is kept in game.
}