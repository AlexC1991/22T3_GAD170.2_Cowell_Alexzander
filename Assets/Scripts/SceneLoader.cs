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
        [HideInInspector]
        [SerializeField] private GameObject greenHouseUI;
        [HideInInspector]
        [SerializeField] private PlantDictionary plantDict;
        [HideInInspector]
        [SerializeField] private GameObject canvasGame;
        [HideInInspector]
        [SerializeField] private GameObject canvasGreenRoom;
        [HideInInspector]
        [SerializeField] private LeaderBoard leaderB;
        [SerializeField] private FloatSO storeData;
        public void ChangeToGreenHouseRoom()
        {

            {
                canvasGame.GetComponent<CanvasGroup>().alpha = 0;
                canvasGame.GetComponent<CanvasGroup>().blocksRaycasts = false;
                canvasGreenRoom.GetComponent<CanvasGroup>().alpha = 1;
                canvasGreenRoom.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }

        } // Changes from the main game screen to the green house screen.
        public void Resume()
        {
            canvasGame.GetComponent<CanvasGroup>().alpha = 1;
            canvasGame.GetComponent<CanvasGroup>().blocksRaycasts = true;
            canvasGreenRoom.GetComponent<CanvasGroup>().alpha = 0;
            canvasGreenRoom.GetComponent<CanvasGroup>().blocksRaycasts = false;

        } // Resumes the game from the green house screen and shows only the main game.
        public void StartGame()
        {
            SceneManager.LoadScene(sceneName: "Greenhouse");
            storeData.Health = 0;
            storeData.Price = 0;
        } // Calls for the main game scene to be started.

        public void Leaderboard()
        {
            SceneManager.LoadScene(sceneName: "Leaderboard");
        }  // Calls for the scene manger to load the leaderboard scene.

        public void ExitGame()
        {
            Application.Quit();
        } // Calls for the game to quit at anytime back to the desktop.

        public void MainMenu()
        {
            SceneManager.LoadScene(sceneName: "Main Menu");
        } // Calls for the main menu scene to be started.

    }
}
