using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Health;
    [SerializeField]
    private TextMeshProUGUI Timer;
    private float timeLeft;
    [SerializeField]
    private TextMeshProUGUI BuffInfo;
    private float buffLeft;

    private GameObject player;
    private PlayerController Player;

    private GameObject buttonManager;
    private ButtonManager ButtonManager;

    void Start()
    {
        timeLeft = 90;
        buffLeft = 5;
        buttonManager = GameObject.FindGameObjectWithTag("ButtonManager");
        ButtonManager = buttonManager.GetComponent<ButtonManager>();
        SceneCheck();
        if (ButtonManager.currentScene != "Tiny_Shell_MainMenu")
        {
            player = GameObject.FindGameObjectWithTag("Player");
            Player = player.GetComponent<PlayerController>();
        }
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (ButtonManager.currentScene != "Tiny_Shell_MainMenu")
        {
            GameFinishedLogic();
            UpdateHUDElements();
            UpdateBuffHUDElement();
        }
    }

    private void FixedUpdate()
    {
        if (ButtonManager.currentScene != "Tiny_Shell_MainMenu")
        {
            Timers();
        }
    }

    private void SceneCheck()
    {
        if (ButtonManager.currentScene == "Tiny_Shell_MainMenu")
        {
            ButtonManager.inMainMenu = true;
        }
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
        else if (Player.InBush == true)
        {
            BuffInfo.text = "Hiding in bush";
        }
        else if (Player.AbilityReady != null && Player.UsingAbility == false)
        {
            BuffInfo.text = $"No active buff\n{Player.AbilityReady} Ability is ready! Press F to activate";
        }
        else if (Player.AbilityReady == null)
        {
            BuffInfo.text = "No active buff";
        }
    }

    public void GameFinishedLogic()
    {
        if (Player.Died == true)
        {
            Time.timeScale = 0;
            ButtonManager.EndMenu.SetActive(true);
            ButtonManager.MiddleText.text = "You have died!";
        }
        else if (Player.ReachedWater == true)
        {
            Time.timeScale = 0;
            ButtonManager.EndMenu.SetActive(true);
            ButtonManager.MiddleText.text = "You reached the water!";
        }
        else if (timeLeft <= 0)
        {
            Time.timeScale = 0;
            ButtonManager.EndMenu.SetActive(true);
            ButtonManager.MiddleText.text = "You failed to reach the water in time!";
        }
    }
}