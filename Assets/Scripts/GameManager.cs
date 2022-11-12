
using UnityEngine;
using UnityEngine.UI;


namespace AlexzanderCowell
{


    public class GameManager : MonoBehaviour
    {
        [HideInInspector]
        [SerializeField] private Text roundCounter;
        [HideInInspector]
        [SerializeField] private PlantDictionary plantDict;
        [HideInInspector]
        [SerializeField] private SceneLoader sceneLoader;
        /// Round count down clock
        [SerializeField] private GameObject onMusic;
        [SerializeField] private GameObject offMusic;
        [HideInInspector]
        public int roundClickMax = 20;
        [HideInInspector]
        public int roundClickMin = 0;
        public void RoundCountDown()
        {
            roundClickMax -= (1);

            roundCounter.text = "Rounds: " + roundClickMax.ToString();

            if (roundClickMax == (1))
            {
                plantDict.EndOfRounds();
                roundCounter.text = "Last Flower".ToString();
            }


            if (roundClickMax == roundClickMin)
            {
                sceneLoader.Leaderboard();
            }

        } // Round count down to be activated in game.


        public void MusicOn()
        {
            onMusic.GetComponent<CanvasGroup>().alpha = 1;
            onMusic.GetComponent<CanvasGroup>().blocksRaycasts = true;
            offMusic.GetComponent<CanvasGroup>().alpha = 0;
            offMusic.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        public void MusicOff()
        {
            offMusic.GetComponent<CanvasGroup>().alpha = 1;
            offMusic.GetComponent<CanvasGroup>().blocksRaycasts = true;
            onMusic.GetComponent<CanvasGroup>().alpha = 0;
            onMusic.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

}
