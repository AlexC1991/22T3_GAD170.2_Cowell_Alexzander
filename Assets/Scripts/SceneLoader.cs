using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace AlexzanderCowell
{

}
public class SceneLoader : MonoBehaviour
{
    private bool checkingGreen = false;
    [SerializeField] PlantsList plantsL;
    GameManager gameManager;
    public void StartGame()
    {
         //gp = FindObjectOfType<Gameplay>();
        //gp.checkingGreen = false;
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

    public void GreenHouseRoom()
    {
        SceneManager.LoadScene(sceneName: "Greenhouse Room", LoadSceneMode.Additive);
    }

}
