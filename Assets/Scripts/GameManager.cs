using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AlexzanderCowell
{

}
public class GameManager : MonoBehaviour{
    
    private int changePlant;
    [SerializeField] PlantsList plantList;
    private void Update(){
        changePlant = (UnityEngine.Random.Range(0, 11));
    }

    public void PlantChanging(){
        if (changePlant == (0)){
            plantList.Plant0();
        }

        if (changePlant == (1)){
            plantList.Plant1();
        }

        if (changePlant == (2)){
            plantList.Plant2();
        }

        if (changePlant == (3)){
            plantList.Plant3();
        }
        if (changePlant == (4)){
            plantList.Plant4();
        }
        if (changePlant == (5)){
            plantList.Plant5();
        }
        if (changePlant == (6))
        {
            plantList.Plant6();
        }

        if (changePlant == (7))
        {
            plantList.Plant7();
        }

        if (changePlant == (8))
        {
            plantList.Plant8();
        }

        if (changePlant == (9))
        {
            plantList.Plant9();
        }
        if (changePlant == (10))
        {
            plantList.Plant10();
        }
        if (changePlant == (11))
        {
            plantList.Plant11();
        }
    }


}
