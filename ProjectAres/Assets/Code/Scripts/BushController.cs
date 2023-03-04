using Unity.VisualScripting;
using UnityEngine;

public class BushController : MonoBehaviour
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
            Player.Hidding(true);
            Player.InBush = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other != null && other.gameObject.CompareTag("HiddenPlayer"))
        {
            Player.Hidding(false);
            Player.InBush = false;
        }
    }
}
