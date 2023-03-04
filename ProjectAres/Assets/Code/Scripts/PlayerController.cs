using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    public int Health { get; private set; }
    public bool Died { get; private set; }
    public bool ReachedWater { get; private set; }
    public bool GameOver { get; private set; }

    public string ActiveBuff { get; private set; }
    public bool UsingAbility;
    public bool InBush;

    public string AbilityReady { get; private set; }
    public string AbilityName;

    private GameObject enemy;
    private EnemyController Enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        Enemy = enemy.GetComponent<EnemyController>();
        ActiveBuff = "";
        speed = 4;
        rb = GetComponent<Rigidbody>();
        Health = 20;
    }

    void Update()
    {
        PauseControl();
        if (Input.GetKeyDown(KeyCode.G))
        {
            AbilityReady = "Sneak";
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            AbilityReady = "Speed";
        }
        ActivateBuff();
    }

    void FixedUpdate()
    {
        PlayerMovement();
    }

    public void HealthManagement(int amount)
    {
        Health = Health + amount;

        if (Health <= 0)
        {
            Died = true;
        }
    }

    public void BuffManagement(string name)
    {
        if (name == "Sneak")
        {
            UsingAbility = true;
            ActiveBuff = "Sneak";
            transform.gameObject.tag = "HiddenPlayer";
            Enemy.trackingPlayer = false;
        }
        if (name == "Speed")
        {
            UsingAbility = true;
            ActiveBuff = "Speed Boost";
            speed = 6;
        }
    }

    public void ResetBuffs()
    {
        speed = 4;
        transform.gameObject.tag = "Player";
    }

    public void BuffControl(string name)
    {
        if (AbilityName != null)
        {
            AbilityName = name;
            AbilityReady = name;
        }
    }

    public void ActivateBuff()
    {
        if (Time.timeScale == 1 && AbilityReady != null && Input.GetKeyDown(KeyCode.J))
        {
            BuffManagement(AbilityReady);
        }
    }

    public void Hidding(bool inBush)
    {
        if (inBush == true)
        {
            transform.gameObject.tag = "HiddenPlayer";
            Enemy.trackingPlayer = false;
        }
        if (inBush == false)
        {
            transform.gameObject.tag = "Player";
        }

    }


    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += speed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= speed * Time.deltaTime * transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= speed * Time.deltaTime * transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * Time.deltaTime * transform.right;
        }
    }

    private void PauseControl()
    {
        if (Input.GetKey(KeyCode.P) || Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
        }
    }
}
