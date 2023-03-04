using UnityEngine;

public class BushController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
