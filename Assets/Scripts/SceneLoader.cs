using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


namespace AlexzanderCowell
{


    public class SceneLoader : MonoBehaviour
    {
        GameManager gameManager;
        [SerializeField] GameObject greenHouseUI;
        [SerializeField] PlantDictionary plantDict;
        [SerializeField] GameObject canvasGame;
        [SerializeField] GameObject canvasGreenRoom;
        [SerializeField] LeaderBoard leaderB;
        public void ChangeToGreenHouseRoom()
        {

            {
                canvasGame.GetComponent<CanvasGroup>().alpha = 0;
                canvasGreenRoom.GetComponent<CanvasGroup>().alpha = 1;
            }

        }
        public void Resume()
        {
            canvasGame.GetComponent<CanvasGroup>().alpha = 1;
            canvasGreenRoom.GetComponent<CanvasGroup>().alpha = 0;

        }
        public void StartGame()
        {
            SceneManager.LoadScene(sceneName: "Greenhouse");


        }

        public void Leaderboard()
        {
            SceneManager.LoadScene(sceneName: "Leaderboard");
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(sceneName: "Main Menu");
        }

    }
}
