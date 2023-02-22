using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private string currentScene;
    private Scene activeScene;
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

    void Update()
    {
        activeScene = SceneManager.GetActiveScene();
        currentScene = activeScene.name;
        if (currentScene == "Testing Environment")
        {
            inMainMenu = true;
        }
        else if (currentScene != "Testing Environment")
        {
            inMainMenu = false;
        }
    }

    void FixedUpdate()
    {
        if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(false);
        }

        if (isPaused == true)
        {
            pauseMenu.SetActive(true);
        }

        if (Time.timeScale == 0)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
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
    }

    public void About()
    {
        aboutMenu.SetActive(true);
        inAboutMenu = true;
        pauseMenu.SetActive(false);
        if (inMainMenu == true)
        {
            mainMenu.SetActive(false);
        }
    }

    public void Controls()
    {
        controlMenu.SetActive(true);
        inControlMenu = true;
        pauseMenu.SetActive(false);
        aboutMenu.SetActive(false);
        if (inMainMenu == true)
        {
            mainMenu.SetActive(false);
        }
    }

    public void Credit()
    {
        creditMenu.SetActive(true);
        inCreditMenu = true;
        pauseMenu.SetActive(false);
        aboutMenu.SetActive(false);
        if (inMainMenu == true)
        {
            mainMenu.SetActive(false);
        }
    }

    public void Back()
    {
        if (inMainMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu = false;
            aboutMenu.SetActive(true);
            return;
        }
        else if (inMainMenu == false && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            inCreditMenu= false;
            pauseMenu.SetActive(true);
            return;
        }

        if (inMainMenu == true && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu = false;
            aboutMenu.SetActive(true);
            return;
        }
        else if (inMainMenu == false && inControlMenu == true)
        {
            controlMenu.SetActive(false);
            inControlMenu= false;
            pauseMenu.SetActive(true);
            return;
        }

        if (inMainMenu == true && inAboutMenu == true)
        {
            aboutMenu.SetActive(false);
            inAboutMenu= false;
            mainMenu.SetActive(true);
            return;
        }
        else if (inMainMenu == false && inAboutMenu == true)
        {
            aboutMenu.SetActive(false);
            inAboutMenu= false;
            pauseMenu.SetActive(true);
            return;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
