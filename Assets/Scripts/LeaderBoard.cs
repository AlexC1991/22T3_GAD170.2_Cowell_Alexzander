
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using JetBrains.Annotations;
using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;

namespace AlexzanderCowell
{


    public class LeaderBoard : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Text printItOut;
        [SerializeField] FloatSO storedData;
        private int totalPoints;
        private float convertMeInt;
         private Transform entryContainer;
         private Transform entryTemplate;
        [SerializeField] private GameObject inputCanvas;
        [SerializeField] private GameObject leaderCanvas;
        private float templateHeight = 0.7f;
        private List<Transform> highscoreEntryTransformList;
        [SerializeField] InputField namePut;
        private string convertedInput;

        private void Awake()
        {
            convertMeInt = storedData.Health;
            convertMeInt += storedData.Price;
            totalPoints = Convert.ToInt32(convertMeInt);    
            
            entryContainer = transform.Find("LeaderboardBox");
            entryTemplate = entryContainer.Find("LeaderboardEntry"); 
            entryTemplate.gameObject.SetActive(false);

            

            


            string jsonString = PlayerPrefs.GetString("PlantScoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            for (int i = 0; i < highscores.highscoreentryList.Count; i++)
            {
                for (int j = i + 1; j < highscores.highscoreentryList.Count; j++)
                {
                    if (highscores.highscoreentryList[j].score == highscores.highscoreentryList[i].score)
                    {
                        HighscoreEntry tmp = highscores.highscoreentryList[i];
                        highscores.highscoreentryList[i] = highscores.highscoreentryList[j];
                        highscores.highscoreentryList[j] = tmp;
                    }
                }
            }
            highscoreEntryTransformList = new List<Transform>();
            foreach (HighscoreEntry highscoreEntry in highscores.highscoreentryList)
            {
                CreateNewEntry(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        }

        private void CreateNewEntry(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
        {
                Transform entryTransform = Instantiate(entryTemplate, container);
                RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
                entryRectTransform.anchoredPosition = new Vector2(0.52f, -templateHeight * transformList.Count);
                entryTemplate.gameObject.SetActive(true);       
                
            if (transformList.Count == 8){
                transformList.RemoveAt(8);
            }
                  int rank = transformList.Count + 1;
                  string rankString;
                   switch (rank){
                    default: rankString = rank + "th"; break;

                    case 1: rankString = "1st"; break;
                    case 2: rankString = "2nd"; break;
                    case 3: rankString = "3rd"; break;

            }

                
                entryTransform.Find("posText").GetComponent<Text>().text = rankString;

                int score = highscoreEntry.score;

                entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();

                string name = highscoreEntry.name;
                entryTransform.Find("nameText").GetComponent<Text>().text = name;

                transformList.Add(entryTransform);

            
        }

        public void Change()
        {
            inputCanvas.GetComponent<CanvasGroup>().alpha = 0;
            inputCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
            leaderCanvas.GetComponent<CanvasGroup>().alpha = 1;
            leaderCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

        public void Resumeit()
        {
            inputCanvas.GetComponent<CanvasGroup>().alpha = 1;
            inputCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
            leaderCanvas.GetComponent<CanvasGroup>().alpha = 0;
            leaderCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }


        public void NewIt()
        {            
            AddHighscores(totalPoints, namePut.ToString());
        }
        private void AddHighscores(int score, string name){
            HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };
            string jsonString = PlayerPrefs.GetString("PlantScoreTable");
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

            highscores.highscoreentryList.Add(highscoreEntry);
            string json = JsonUtility.ToJson(highscores);
            PlayerPrefs.SetString("PlantScoreTable", json);
            PlayerPrefs.Save();
        }
        private class Highscores
        {
            public List<HighscoreEntry> highscoreentryList;
        }
        [System.Serializable]
        private class HighscoreEntry
        {
            public int score;
            public string name;
        }

    }
}
