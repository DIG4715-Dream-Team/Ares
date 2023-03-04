using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Health;
    [SerializeField]
    private TextMeshProUGUI Timer;
    private float timeLeft;
    [SerializeField]
    private TextMeshProUGUI MiddleText;
    [SerializeField]
    private TextMeshProUGUI BuffInfo;
    private float buffLeft;

    private GameObject player;
    private PlayerController Player;
    [SerializeField]
    public string currentScene { get; private set; }
    [SerializeField]
    public Scene activeScene { get; private set; }
    private bool isPaused;

    [SerializeField]
    private GameObject mainMenu;
    private bool inMainMenu;
    [SerializeField]
    private GameObject aboutMenu;
    private bool inAboutMenu;
    [SerializeField]
    private GameObject controlMenu;
    private bool inControlMenu;
    [SerializeField]
    private GameObject creditMenu;
    private bool inCreditMenu;
    [SerializeField]
    private GameObject pauseMenu;
    private bool inPauseMenu;
    [SerializeField]
    private GameObject endMenu;

    void Start()
    {
        timeLeft = 90;
        buffLeft = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        Player = player.GetComponent<PlayerController>();
        HUDPreset();
    }

    private void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;
        PauseLogic();
        GameFinishedLogic();
        UpdateHUDElements();
        UpdateBuffHUDElement();
    }

    private void FixedUpdate()
    {
        Timers();
    }

    private void Timers()
    {
        timeLeft = timeLeft -= Time.deltaTime;

        if (Player.UsingAbility == true)
        {
            buffLeft = buffLeft -= Time.deltaTime;
            if (buffLeft <= 0)
            {
                Player.UsingAbility = false;
                buffLeft = 5;
                Player.ResetBuffs();
            }
        }
    }

    private void UpdateHUDElements()
    {
        Health.text = $"Current Health:{Player.Health}";
        Timer.text = $"Time Left:{timeLeft.ToString("F1")}";
    }

    private void UpdateBuffHUDElement()
    {
        if (Player.UsingAbility == true)
        {
            BuffInfo.text = $"Ability:{Player.ActiveBuff} \nTime Left:{buffLeft.ToString("F1")}";
        }
        else if (Player.AbilityReady != null && Player.UsingAbility == false)
        {
            BuffInfo.text = $"No active buff.\n{Player.AbilityReady} Ability is ready!";
        }
        else if (Player.AbilityReady == null)
        {
            BuffInfo.text = "No active buff.";
        }

        if (Player.InBush == true)
        {
            BuffInfo.text = "Hiding in bush.";
        }
        else
        {
            BuffInfo.text = "No active buff.";
        }
    }

    private void HUDPreset()
    {
        if (currentScene == "Tiny_Shell_MainMenu")
        {
            MiddleText.text = "Change me in GameManager HUDPreset";
            mainMenu.SetActive(true);
            aboutMenu.SetActive(false);
            controlMenu.SetActive(false);
            creditMenu.SetActive(false);
            pauseMenu.SetActive(false);
            endMenu.SetActive(false);
        }
        else
        {
            mainMenu.SetActive(false);
            aboutMenu.SetActive(false);
            controlMenu.SetActive(false);
            creditMenu.SetActive(false);
            pauseMenu.SetActive(false);
            endMenu.SetActive(false);
        }
    }

    private void PauseLogic()
    {
        if (Player.GameOver == false)
        {
            if (currentScene != "Tiny_Beach_MainMenu" && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                Time.timeScale = 0;
                isPaused = true;
            }

            if (isPaused == true & inPauseMenu == false)
            {
                pauseMenu.SetActive(true);
                inPauseMenu = true;
            }

            if (Time.timeScale == 1)
            {
                pauseMenu.SetActive(false);
                inPauseMenu = false;
            }
        }
    }

    public void GameFinishedLogic()
    {
        if (Player.Died == true)
        {
            Time.timeScale = 0;
            endMenu.SetActive(true);
            MiddleText.text = "You have died!";
        }
        else if (Player.ReachedWater == true)
        {
            Time.timeScale = 0;
            endMenu.SetActive(true);
            MiddleText.text = "You reached the water!";
        }
        else if (timeLeft <= 0)
        {
            Time.timeScale = 0;
            endMenu.SetActive(true);
            MiddleText.text = "You failed to reach the water in time!";
        }
    }

    private void CheckActivity()
    {
        if (inMainMenu == true)
        {
            mainMenu.SetActive(false);
        }
        else if (inPauseMenu == true)
        {
            pauseMenu.SetActive(false);
        }
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        inMainMenu = false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseLogic();
        MiddleText.text = "";
    }

    public void About()
    {
        CheckActivity();
        aboutMenu.SetActive(true);
        inAboutMenu = true;
        MiddleText.text = "Options";

    }

    public void Controls()
    {
        controlMenu.SetActive(true);
        inControlMenu = true;
        pauseMenu.SetActive(false);
        aboutMenu.SetActive(false);
        CheckActivity();
        MiddleText.text = "Controls";
    }

    public void Credit()
    {
        creditMenu.SetActive(true);
        inCreditMenu = true;
        pauseMenu.SetActive(false);
        aboutMenu.SetActive(false);
        CheckActivity();
        MiddleText.text = "Credit";
    }

    public void Back()
    {
        if (inMainMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
        else if (inMainMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }

        if (inMainMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
        else if (inMainMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }

        if (inMainMenu == true && inAboutMenu == true)
        {
            aboutMenu.SetActive(false);
            inAboutMenu = false;
            mainMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inMainMenu == false && inAboutMenu == true)
        {
            aboutMenu.SetActive(false);
            inAboutMenu = false;
            pauseMenu.SetActive(true);
            MiddleText.text = "Game Paused";
            return;
        }

        if (inMainMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
        else if (inMainMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }

        if (inMainMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
        else if (inMainMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }



        if (inPauseMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
        else if (inPauseMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }

        if (inPauseMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
        else if (inPauseMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }

        if (inPauseMenu == true && inAboutMenu == true)
        {
            aboutMenu.SetActive(false);
            inAboutMenu = false;
            mainMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inPauseMenu == false && inAboutMenu == true)
        {
            aboutMenu.SetActive(false);
            inAboutMenu = false;
            pauseMenu.SetActive(true);
            MiddleText.text = "Game Paused";
            return;
        }

        if (inPauseMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
        else if (inPauseMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }

        if (inPauseMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
        else if (inPauseMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "Options";
            return;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void QuitToMain(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        inMainMenu = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}