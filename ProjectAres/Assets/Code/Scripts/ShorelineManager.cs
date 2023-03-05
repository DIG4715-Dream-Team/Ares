using UnityEngine;

public class ShorelineManager : MonoBehaviour
{
    private GameObject player;
    private PlayerController Player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Player = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            Player.ReachedWater = true;
        }
    }
}
