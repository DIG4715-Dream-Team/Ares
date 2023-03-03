using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI health;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private TextMeshProUGUI score;

    private string currentScene;
    private Scene activeScene;

    [SerializeField]
    private GameObject pauseMenu;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;
        //updateText();
    }

    private void updateText()
    {
        //health.text = $"Current Health:{player.GetComponent<PlayerController>().Health}";
        //score.text = $"Score: {player.GetComponent<PlayerController>().Score}";
    }

    private void SceneMananger()
    {
        //if (currentScene == "Tiny_Beach_MainMenu")
    }
}
