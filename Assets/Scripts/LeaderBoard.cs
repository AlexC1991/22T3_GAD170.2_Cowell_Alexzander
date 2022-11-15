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
		
        
		private Highscores highscores;
		private int num_scores = 0; //Number of scores
        
        //Const Strings for the names of the Save Data keys. Change these here to try with new Save Data quickly
        private const string save_file_num_of_scores_name = "SFNOSabcdef";
        private const string save_file_score_name = "SFSabcdef";
        private const string save_file_name_name = "SFNabcdef";

        public static int type = 0; //Depending on whether accessed from Menu or Gameplay session
        private byte i;
    
		
        private void Awake()
        {
            convertMeInt = storedData.Health; // Transfered Health Score
            convertMeInt += storedData.Price; // Transfered Price Score.
            totalPoints = Convert.ToInt32(convertMeInt); // Converting float to a int. 

            highscoreEntryTransformList = new List<Transform>(); ////////////////////////


            entryContainer = transform.Find("LeaderboardBox"); // finding child called LeaderboardBox.


            ///////////////////////////////////////////////////////////////////
			///////////////////////////////////////////////////////////////////
            ///
            
            //Num of scores save data loading(If it has it, otherwise creating new with starting val of 0)
			if (PlayerPrefs.HasKey(save_file_num_of_scores_name))
			{
				num_scores = PlayerPrefs.GetInt(save_file_num_of_scores_name);
                Debug.Log("NumberOfScoresSave found: " + num_scores.ToString());
			}
			else
			{
                Debug.Log("NumberOfScoresSave not found ");
				num_scores = 0;
				PlayerPrefs.SetInt(save_file_num_of_scores_name, 0);
                PlayerPrefs.Save();
			}

            //Making ScoreList list based on Save Data:
            highscores = new Highscores();

            for (i = 0; i < num_scores; i++)
            {
                HighscoreEntry he = new HighscoreEntry();
                he.score = PlayerPrefs.GetInt(save_file_score_name + (i+1).ToString());
                he.name = PlayerPrefs.GetString(save_file_name_name + (i+1).ToString());
                Debug.Log((i+1).ToString() + ")" + he.name + ": " + he.score);
                highscores.ScoreList.Add(he);
			}

            //If accessed from Main Menu showing the list right away, rather than after adding a new score
            if (type == 0) 
			{
                ChangeList();
			}
            ///
			////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////
            

             // Updating Leaderboard with new details.
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
        private void ChangeList()
        {
            /*
            for (i = 0; i < highscores.ScoreList.Count; i++)
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
            }*/
            //highscores.ScoreList.Sort((x, y) => x.score.CompareTo(y.score));


            //Temp array... Giving it the same values as the highscores array
            List<HighscoreEntry> ta = new List<HighscoreEntry>();
            for (i = 0; i < highscores.ScoreList.Count; i++)
            {
                ta.Add(highscores.ScoreList[i]);
            }

            //Then sorted array:
            List<HighscoreEntry> sorted_list = new List<HighscoreEntry>();

            while (ta.Count > 0 && sorted_list.Count < 8)
            {
                int max_val = -1000;
                int max_val_index = 0;
                for (i = 0; i < ta.Count; i++)
                {
                    if (ta[i].score > max_val)
				    {
                        max_val = ta[i].score;
                        max_val_index = i;
				    }
			    }
                sorted_list.Add(ta[max_val_index]);
                ta.RemoveAt(max_val_index);
            }

            highscores.ScoreList = new List<HighscoreEntry>(); //Also gonna refresh the highscores.ScoreList to match sorted_list
            PlayerPrefs.SetInt(save_file_num_of_scores_name, sorted_list.Count); //Amount of score entries
            //Displaying list:
            for (i = 0; i < Math.Min(sorted_list.Count, 8); i++)
            {
                highscores.ScoreList.Add(sorted_list[i]); //highscores.ScoreList will be the same as sorted_list after this for loop
                
                //Saving Values accordingly:
			    PlayerPrefs.SetInt(save_file_score_name + (i + 1).ToString(), sorted_list[i].score);
                PlayerPrefs.SetString(save_file_name_name + (i + 1).ToString(), sorted_list[i].name);
                PlayerPrefs.Save();

                CreateNewEntry(sorted_list[i], entryContainer, highscoreEntryTransformList, i);
			}
        }

        private void CreateNewEntry(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList, int ind)
        {
            Transform entryTransform = Instantiate(entryTemplate, container);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            //entryRectTransform.anchoredPosition = new Vector2(1.2f,-templateHeight * transformList.Count + ind * 1.333f);//new Vector2(0.52f, -templateHeight * transformList.Count);
            entryRectTransform.anchoredPosition = new Vector2(0.52f, -templateHeight * highscoreEntryTransformList.Count);
            entryTransform.gameObject.SetActive(true);

            highscoreEntryTransformList.Add(entryTransform); //////////////////////////////////////

            //if (transformList.Count == 8)
            //{
                //transformList.RemoveAt(8);
            //}

            int rank = highscoreEntryTransformList.Count;

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

            Debug.Log("Highscore entry: " + name + " " + score);
			

            /////////////////////////////////////////////
            /////////////////////////////////////////////
            ////
			num_scores++;

            PlayerPrefs.SetInt(save_file_num_of_scores_name, num_scores);
			PlayerPrefs.SetInt(save_file_score_name + num_scores.ToString(), score);
            PlayerPrefs.SetString(save_file_name_name + num_scores.ToString(), name);
            PlayerPrefs.Save();

            highscores.ScoreList.Add(highscoreEntry);

            Debug.Log("Num scores = " + num_scores);
            /////////////////////////////////////////////

            currentScore = highscoreEntry;

            Debug.Log("Finsihed Adding Score");

            ChangeList(); /////////////////////////////////
        } // Adds the Input Field name + Total Score and adds it into a list class and than saves that class details to a JsonFile using PlayerPrefs.



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
    }
}
