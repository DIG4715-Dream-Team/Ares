using UnityEngine;

public class BushController : MonoBehaviour
{
    private void OnTriggerEnter(Collision other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
