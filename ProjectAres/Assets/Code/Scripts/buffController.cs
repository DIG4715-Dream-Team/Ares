using UnityEngine;

public class BuffController : MonoBehaviour
{
    private GameObject player;
    private PlayerController Player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Player = player.GetComponent<PlayerController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Speed"))
            {
                Player.BuffControl("Speed");
                Destroy(this.gameObject);
            }
            else if (this.gameObject.CompareTag("Sneak"))
            {
                Player.BuffControl("Sneak");
                Destroy(this.gameObject);
            }
        }
    }
}
