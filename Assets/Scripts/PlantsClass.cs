using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


namespace AlexzanderCowell
{

}
public class PlantsClass
{
    [SerializeField] PlantDictionary plantDict;

    // Plant Names in the List //
    public string plantD;
    
    // Max Price & Health Range for Plants in the List //
    public int maxPrice;
    public int maxHealth;

    // Plant names / price / health for the list
    public PlantsClass(string newPlant, int newPrice, int newHealth)
    {
        plantD = newPlant;
        maxPrice = newPrice;
        maxHealth = newHealth;       
    }

}
