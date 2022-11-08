using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace AlexzanderCowell
{


    public class Plant : MonoBehaviour

    {
        // Plant Names in the List //
        public string plantName;

        // Max Price & Health Range for Plants in the List //
        public int maxPrice;
        public int maxHealth;

        // Plant names / price / health for the list
        public Plant(string newPlantName, int newPrice, int newHealth)
        {
            plantName = newPlantName;
            maxPrice = newPrice;
            maxHealth = newHealth;
        }

    }
}