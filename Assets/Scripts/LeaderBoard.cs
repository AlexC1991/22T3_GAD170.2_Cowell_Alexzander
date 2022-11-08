using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


namespace AlexzanderCowell
{


    public class LeaderBoard : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Text printItOut;
        [SerializeField] GameManager gameM;
        [SerializeField] PlantDictionary plantDictionary;
        private int pointTotalH;
        private int pointTotalP;
        private int totalPoints;


        private void Update()
        {

        }
        private void SaveData()
        {
        }
        public void StartKey()
        {
            foreach (Plant plant in plantDictionary.plantList) { 
            
                if (gameM.roundClickMax == gameM.roundClickMin)
                {
                    pointTotalH = plant.maxHealth;
                    pointTotalP = plant.maxPrice;
                    totalPoints = pointTotalH + pointTotalP;
                    Debug.Log(totalPoints);
                }

            }
            
        }

    }
}
