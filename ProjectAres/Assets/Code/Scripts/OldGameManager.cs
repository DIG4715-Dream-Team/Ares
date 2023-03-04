using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OldGameManager : MonoBehaviour
{
    //[SerializeField]
    //private TextMeshProUGUI health;
    //[SerializeField]
    //private GameObject player;
    //[SerializeField]
    //private TextMeshProUGUI score;

    //private string currentScene;
    //private Scene activeScene;

    [SerializeField]
    private GameObject pauseMenu;
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        //activeScene = SceneManager.GetActiveScene();
        //currentScene = activeScene.name;
        //updateText();
    }

    //private void updateText()
    //{
    //    health.text = $"Current Health:{player.GetComponent<PlayerController>().health}";
    //    score.text = $"Time Left: {player.GetComponent<PlayerController>().timeLeft}";
    //}

    private void SceneMananger()
    {
        //if (currentScene == "Tiny_Beach_MainMenu")
    }
}
