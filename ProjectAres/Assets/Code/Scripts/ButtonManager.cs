using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    private string currentScene;
    private Scene activeScene;
    private bool isPaused;

    [SerializeField]
    private GameObject mainMenu;
    private bool inMainMenu = true;
    [SerializeField]
    private GameObject aboutMenu;
    private bool inAboutMeny;
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
        inAboutMeny = true;
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
        ChangeBools(inCreditMenu, true);
        pauseMenu.SetActive(false);
        aboutMenu.SetActive(false);
        if (inMainMenu == true)
        {
            mainMenu.SetActive(false);
        }
    }

    public void Back()
    {
        Debug.Log(inMainMenu);
        Debug.Log(inCreditMenu);
        if (inMainMenu == true && inCreditMenu == true)
        {
            creditMenu.SetActive(false);
            aboutMenu.SetActive(true);
            Debug.Log("I should work");
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

    public void ChangeBools(bool name, bool set)
    {
        name = set;
    }
}
