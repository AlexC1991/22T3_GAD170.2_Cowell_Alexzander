using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;


namespace AlexzanderCowell
{

}
public class PlantLoggingClass     
{
    [SerializeField] PlantDictionary plantDict;
    // List Stat Variables //
    public string _plantName;
    public string _word3;
    public int _plantPrice;
    public int _plantHealth;
    public string _endingWords;


    // Stored List Stats,
    public PlantLoggingClass(string wordsAndPlantName, int plantPrice, string words3, int plantHealth, string endingWords)
    {      
        _plantName = wordsAndPlantName;
        _plantPrice = plantPrice;
        _word3 = words3;
        _plantHealth = plantHealth;
        _endingWords = endingWords;

    }


}

