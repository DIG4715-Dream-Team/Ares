using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    //private string currentScene;
    //private Scene activeScene;
    private bool isPaused;
    public bool wonGame;
    //private GameObject player;

    //[SerializeField]
    //private GameObject mainMenu;
    //private bool inMainMenu;
    //[SerializeField]
    //private GameObject aboutMenu;
    //private bool inAboutMenu;
    //[SerializeField]
    //private GameObject controlMenu;
    //private bool inControlMenu;
    //[SerializeField]
    //private GameObject creditMenu;
    //private bool inCreditMenu;
    //[SerializeField]
    //private GameObject pauseMenu;
    //private bool inPauseMenu;
    //[SerializeField]
    //private GameObject endMenu;

    [SerializeField]
    private TextMeshProUGUI endText;

    //private void EndGameLogic()
    //{
    //    if (Time.timeScale == 0 && player.GetComponent<PlayerController>().reachedWater == true)
    //    {
    //        endMenu.SetActive(true);
    //        endText.text = "You've Won!";
    //    }
    //    else if (Time.timeScale == 0 && player.GetComponent<PlayerController>().died == true)
    //    {
    //        endMenu.SetActive(true);
    //        endText.text = "You Lost!";
    //    }
    //}
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        //activeScene = SceneManager.GetActiveScene();
        //currentScene = activeScene.name;
        //if (currentScene == "Tiny_Shell_MainMenu")
        //{
        //    HUDPreset1();
        //}
        //else
        //{
        //    HUDPreset2();
        //}
        //MMCheck();
    }

    void Update()
    {
        //PauseLogic();
        //EndGameLogic();
    }

    void FixedUpdate()
    {
    }
   
    //public void StartGame(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //    inMainMenu = false;
    //}

    //public void ResumeGame()
    //{
    //    Time.timeScale = 1;
    //    PauseLogic();
    //}

    //public void About()
    //{
    //    CheckActivity();
    //    aboutMenu.SetActive(true);
    //    inAboutMenu = true;
    //}

    //public void Controls()
    //{
    //    controlMenu.SetActive(true);
    //    inControlMenu = true;
    //    pauseMenu.SetActive(false);
    //    aboutMenu.SetActive(false);
    //    CheckActivity();
    //}

    //public void Credit()
    //{
    //    creditMenu.SetActive(true);
    //    inCreditMenu = true;
    //    pauseMenu.SetActive(false);
    //    aboutMenu.SetActive(false);
    //    CheckActivity();
    //}

    //public void Back()
    //{
    //    if (inMainMenu == true && inCreditMenu == true)
    //    {
    //        creditMenu.SetActive(false);
    //        inCreditMenu = false;
    //        aboutMenu.SetActive(true);
    //        return;
    //    }
    //    else if (inMainMenu == false && inCreditMenu == true)
    //    {
    //        creditMenu.SetActive(false);
    //        inCreditMenu = false;
    //        aboutMenu.SetActive(true);
    //        return;
    //    }

    //    if (inMainMenu == true && inControlMenu == true)
    //    {
    //        controlMenu.SetActive(false);
    //        inControlMenu = false;
    //        aboutMenu.SetActive(true);
    //        return;
    //    }
    //    else if (inMainMenu == false && inControlMenu == true)
    //    {
    //        controlMenu.SetActive(false);
    //        inControlMenu = false;
    //        aboutMenu.SetActive(true);
    //        return;
    //    }

    //    if (inMainMenu == true && inAboutMenu == true)
    //    {
    //        aboutMenu.SetActive(false);
    //        inAboutMenu = false;
    //        mainMenu.SetActive(true);
    //        return;
    //    }
    //    else if (inMainMenu == false && inAboutMenu == true)
    //    {
    //        aboutMenu.SetActive(false);
    //        inAboutMenu = false;
    //        pauseMenu.SetActive(true);
    //        return;
    //    }
    //}

    //public void RestartLevel()
    //{
    //    SceneManager.LoadScene(currentScene);
    //    Time.timeScale = 1;
    //}

    //public void RestartGame()
    //{
    //    SceneManager.LoadScene("MainMenu");
    //    Time.timeScale = 1;
    //}

    //public void QuitToMain(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //    inMainMenu = false;
    //}

    //public void QuitGame()
    //{
    //    Application.Quit();
    //}

    //private void HUDPreset1()
    //{
    //    mainMenu.SetActive(true);
    //    aboutMenu.SetActive(false);
    //    controlMenu.SetActive(false);
    //    creditMenu.SetActive(false);
    //    pauseMenu.SetActive(false);
    //    endMenu.SetActive(false);
    //}

    //private void HUDPreset2()
    //{
    //    mainMenu.SetActive(false);
    //    aboutMenu.SetActive(false);
    //    controlMenu.SetActive(false);
    //    creditMenu.SetActive(false);
    //    pauseMenu.SetActive(false);
    //    endMenu.SetActive(false);
    //}    

    //private void PauseLogic()
    //{
    //    if (Time.timeScale == 0 && isPaused == false)
    //    {
    //        isPaused = true;
    //        pauseMenu.SetActive(true);
    //        inPauseMenu = true;
    //    }

    //    if (Time.timeScale == 1)
    //    {
    //        pauseMenu.SetActive(false);
    //        inPauseMenu = false;
    //        isPaused = false;
    //    }
    //}    
    //private void CheckActivity()
    //{
    //    if (inMainMenu == true)
    //    {
    //        mainMenu.SetActive(false);
    //    }
    //    else if (inPauseMenu == true)
    //    {
    //        pauseMenu.SetActive(false);
    //    }
    //}

    //private void MMCheck()
    //{
    //    if (currentScene == "Tiny_Shell_MainMenu" )
    //    {
    //        inMainMenu = true;
    //    }
    //    else
    //    {
    //        inMainMenu = false;
    //    }
    //}

    //private void checkActiveMenu()
    //{
    //    if (mainMenu.activeInHierarchy == true)
    //    {
    //        inMainMenu = true;
    //    }

    //    if (pauseMenu.activeInHierarchy == true)
    //    {
    //        inPauseMenu = true;
    //    }

    //    if (aboutMenu.activeInHierarchy == true)
    //    {
    //        inAboutMenu = true;
    //    }

    //    if (controlMenu.activeInHierarchy == true)
    //    {
    //        inControlMenu = true;
    //    }

    //    if (creditMenu.activeInHierarchy == true)
    //    {
    //        inCreditMenu = true;
    //    }
    //}
}