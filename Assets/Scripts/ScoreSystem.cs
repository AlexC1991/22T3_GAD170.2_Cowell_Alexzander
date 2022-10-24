using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace AlexzanderCowell
{

}
public class ScoreSystem : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] PlantsList plantList;
    private float scorePrice;
    private float scoreHealth;
    private string scoreArray;
    
    [HideInInspector]
    public float priceTotal = 0;
    [HideInInspector]
    public float healthTotal = 0;
    [HideInInspector]
    public string greenHouse = "";



    
    public void Score()
    {
        scorePrice = plantList.returnPrice;
        scoreHealth = plantList.returnHealth;
        scoreArray = plantList.returnArray;

        ScoreTotal();
    }


    
    public void ScoreTotal()
    {
        priceTotal += scorePrice;
    }


}
