using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private TextMeshProUGUI BuffTimer;
    private float buffLeft;

    [SerializeField]
    private GameObject Player;
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
        Player = GameObject.FindGameObjectWithTag("Player");
        HUDPreset();
    }

    private void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;
        PauseLogic();
    }

    private void FixedUpdate()
    {
        timeLeft = timeLeft -= Time.deltaTime;
        //buffLeft = Player.GetComponent<PlayerController>().BuffTimer -= Time.deltaTime;
    }

    private void UpdateHUDElements()
    {
        //Health.text = $"Current Health:{Player.GetComponent<PlayerController>().Health}";
        Timer.text = $"Time Left:{timeLeft}";
        //BuffTimer.text = $"Player.GetComponent<PlayerController>().ActiveBuff}:Time Left: buffLeft}";
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
        if (currentScene != "Tiny_Beach_MainMenu" && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 0;
            isPaused = true;
        }

        if (isPaused == true)
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

    private void checkActiveMenu()
    {
        if (mainMenu.activeInHierarchy == true)
        {
            inMainMenu = true;
        }

        if (pauseMenu.activeInHierarchy == true)
        {
            inPauseMenu = true;
        }

        if (aboutMenu.activeInHierarchy == true)
        {
            inAboutMenu = true;
        }

        if (controlMenu.activeInHierarchy == true)
        {
            inControlMenu = true;
        }

        if (creditMenu.activeInHierarchy == true)
        {
            inCreditMenu = true;
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
        MiddleText.text = "Change me in GameManager About";
    }

    public void Controls()
    {
        controlMenu.SetActive(true);
        inControlMenu = true;
        pauseMenu.SetActive(false);
        aboutMenu.SetActive(false);
        CheckActivity();
        MiddleText.text = "Change me in GameManager Controls";
    }

    public void Credit()
    {
        creditMenu.SetActive(true);
        inCreditMenu = true;
        pauseMenu.SetActive(false);
        aboutMenu.SetActive(false);
        CheckActivity();
        MiddleText.text = "Change me in GameManager Credit";
    }

    public void Back()
    {
        if (inMainMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inMainMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }

        if (inMainMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inMainMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
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
            MiddleText.text = "";
            return;
        }

        if (inMainMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inMainMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }

        if (inMainMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inMainMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }



        if (inPauseMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inPauseMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }

        if (inPauseMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inPauseMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
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
            MiddleText.text = "";
            return;
        }

        if (inPauseMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inPauseMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }

        if (inPauseMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
            return;
        }
        else if (inPauseMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            MiddleText.text = "";
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