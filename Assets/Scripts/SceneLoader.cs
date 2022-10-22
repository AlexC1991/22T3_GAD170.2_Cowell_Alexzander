using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace AlexzanderCowell
{

}
public class SceneLoader : MonoBehaviour
{
    [SerializeField] PlantsList plantsL;
    GameManager gameManager;
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
