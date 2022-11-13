using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace AlexzanderCowell
{
    public class LeaderBoard : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private Transform entryTemplate;
        [SerializeField] private GameObject inputCanvas;
        [SerializeField] private GameObject leaderCanvas;
        [SerializeField] FloatSO storedData;
        [SerializeField] InputField namePut;
        private HighscoreEntry currentScore;

        private int totalPoints;
        private float convertMeInt;
        private Transform entryContainer;
        private float templateHeight = 0.7f;
        private List<Transform> highscoreEntryTransformList;
        private string convertedInput;
        private string fileName = "PlantScore";
        private void Awake()
        {
            convertMeInt = storedData.Health; // Transfered Health Score
            convertMeInt += storedData.Price; // Transfered Price Score.
            totalPoints = Convert.ToInt32(convertMeInt); // Converting float to a int. 

            entryContainer = transform.Find("LeaderboardBox"); // finding child called LeaderboardBox.

            string jsonString = PlayerPrefs.GetString(fileName); // Getting data from fileName.
            Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString); // Putting the data from Jason into the highscores.

            ChangeList(highscores); // Updating Leaderboard with new details.
        } // Start of the scene and all loaded Variables.


        private void Start()
        {
            if (totalPoints > 0)
            {
                Resumeit();
            }

            else
                Change();
        } // changes the scene depending you come from the game to the leaderboard or from the main menu.
        private void ChangeList(Highscores highscores)
        {
            for (int i = 0; i < highscores.ScoreList.Count; i++)
            {
                for (int j = i + 1; j < highscores.ScoreList.Count; j++)
                {
                    if (highscores.ScoreList[j].score == highscores.ScoreList[i].score)
                    {
                        HighscoreEntry tmp = highscores.ScoreList[i];
                        highscores.ScoreList[i] = highscores.ScoreList[j];
                        highscores.ScoreList[j] = tmp;
                    }
                }
            }

            highscoreEntryTransformList = new List<Transform>();

            foreach (HighscoreEntry highscoreEntry in highscores.ScoreList)
            {

                CreateNewEntry(highscoreEntry, entryContainer, highscoreEntryTransformList);
            }
        } // Sorts the highscore list.

        private void CreateNewEntry(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
        {


            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0.52f, -templateHeight * transformList.Count);
            entryTransform.gameObject.SetActive(true);



            if (transformList.Count == 8)
            {
                transformList.RemoveAt(8);
            }

            int rank = transformList.Count + 1;

            string rankString;

            switch (rank)
            {
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


        } // Adds Entries to the Leaderboard.

        private void Change()
        {
            inputCanvas.GetComponent<CanvasGroup>().alpha = 0;
            inputCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
            leaderCanvas.GetComponent<CanvasGroup>().alpha = 1;
            leaderCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
        } // changes the Canvas alpha and raycasting for the Input field canvas and the leaderboard canvas.

        private void Resumeit()
        {
            inputCanvas.GetComponent<CanvasGroup>().alpha = 1;
            inputCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
            leaderCanvas.GetComponent<CanvasGroup>().alpha = 0;
            leaderCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }// changes the Canvas alpha and raycasting for the Input field canvas and the leaderboard canvas.

        public void NewIt() 
        {
            AddHighscores(totalPoints, namePut.text.ToString());
        } // Takes the Input field text and the total score for the leaderboard.
        private void AddHighscores(int score, string name)
        {
            HighscoreEntry highscoreEntry;

            highscoreEntry = new HighscoreEntry
            {
                score = score,
                name = name
            };

            Highscores _highscores = new Highscores();

            if (PlayerPrefs.HasKey(fileName))
            {
                string jsonString = PlayerPrefs.GetString(fileName);
                Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
                _highscores = highscores;
            }

            _highscores.ScoreList = new List<HighscoreEntry>();
            currentScore = highscoreEntry;
            _highscores.ScoreList.Add(currentScore);
            string json = JsonUtility.ToJson(_highscores);
            PlayerPrefs.SetString(fileName, json);
            PlayerPrefs.Save();
            Debug.Log("Finsihed Adding Score");

            ChangeList(_highscores);
        } // Adds the Input Field name + Total Score and adds it into a list class and than saves that class details to a JsonFile using PlayerPrefs.
    }
}
// public classes
[System.Serializable]
public class Highscores
{
    public List<HighscoreEntry> ScoreList = new List<HighscoreEntry>();
}

[System.Serializable]
public class HighscoreEntry
{
    public int score;
    public string name;
}