using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UI;


namespace AlexzanderCowell
{

}
public class PlantsList : MonoBehaviour{
    public Text plantCaller;
    public Text plantCaller2;

    // Plant List in a Array //
    private List<string> _plantArray = new List<string>();

    // Max Price Range for Plants //
    [Range(15, 30)]
    [SerializeField] private int maxPrice;
    [Range(6, 10)]
    [SerializeField] private int maxHealth;
    // Min Price Range for Plants //
    [Range(1, 14)]
    [SerializeField] private int minPrice;
    [Range(1, 5)]
    [SerializeField] private int minHealth;


    private float randomPrice;
    private float randomHealth;

    protected void Awake(){
        _plantArray.Add("Sun Flower!");
        _plantArray.Add("Rose Bud!");
        _plantArray.Add("White Rose!");
        _plantArray.Add("Gold Rose!");
        _plantArray.Add("Red Hornet!");
        _plantArray.Add("Lotus Leaf!");
        _plantArray.Add("Water Lily!");
        _plantArray.Add("Daisy!");
        _plantArray.Add("Prim Rose!");
        _plantArray.Add("Jasmine!");
        _plantArray.Add("Delilah!");
        _plantArray.Add("Poppy!");
        _plantArray.Add("Daffodils!");
        _plantArray.Add("Iris!");
        _plantArray.Add("Blue Bell!");
        _plantArray.Add("tigerLilly!");
    }

    /// <summary>
    ///  This starts the Plant Generator! //
    /// </summary>
    protected void Update(){
        randomPrice = (UnityEngine.Random.Range(minPrice, maxPrice));
        randomHealth = (UnityEngine.Random.Range(minPrice, maxPrice));
    }

    public void Plant0(){
        plantCaller.text = "You got a "+_plantArray[0]+" the price is "+randomPrice+" & the health of".ToString(); 
        plantCaller2.text = "this "+_plantArray[0]+" is "+randomHealth+". Do you want to keep it or reject it?".ToString();   
    }

    public void Plant1(){
        plantCaller.text = "You got a " + _plantArray[1] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[1] +" is "+ randomHealth +". Do you want to keep it or reject it?".ToString();
    }

    public void Plant2(){
        plantCaller.text = "You got a " + _plantArray[2] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[2] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }

    public void Plant3(){
        plantCaller.text = "You got a " + _plantArray[3] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[3] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }

    public void Plant4(){
        plantCaller.text = "You got a " + _plantArray[4] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[4] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }
    public void Plant5(){
        plantCaller.text = "You got a " + _plantArray[5] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[5] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }

    public void Plant6()
    {
        plantCaller.text = "You got a " + _plantArray[6] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[6] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }

    public void Plant7()
    {
        plantCaller.text = "You got a " + _plantArray[7] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[7] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }

    public void Plant8()
    {
        plantCaller.text = "You got a " + _plantArray[8] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[8] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }

    public void Plant9()
    {
        plantCaller.text = "You got a " + _plantArray[9] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[9] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }

    public void Plant10()
    {
        plantCaller.text = "You got a " + _plantArray[10] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[10] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }
    public void Plant11()
    {
        plantCaller.text = "You got a " + _plantArray[11] + " the price is " + randomPrice + " & the health of".ToString();
        plantCaller2.text = "this " + _plantArray[11] + " is " + randomHealth + ". Do you want to keep it or reject it?".ToString();
    }








}
