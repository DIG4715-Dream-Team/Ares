using UnityEngine.AI;
using UnityEngine;
using Unity.VisualScripting;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public float range;
    public Transform centrePoint;

    private Rigidbody rb;

    private bool trackingPlayer;
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        Patrolling();
    }

    private void Patrolling()
    {
        if (agent.remainingDistance <= agent.stoppingDistance && trackingPlayer == false)
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point))
            {
                Debug.DrawLine(transform.position, point, Color.red, 5.0f);
                Debug.DrawRay(point, Vector3.up, Color.red, 5.0f);
                agent.SetDestination(point);
            }
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            //agent.SetDestination(player.transform.position);
            Debug.DrawLine(transform.position, player.transform.position, Color.magenta, 5.0f);
            Debug.DrawRay(player.transform.position, Vector3.up, Color.magenta, 5.0f);
            trackingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            trackingPlayer = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();
        if (other != null && other.gameObject.CompareTag("Player"))
        {
            player.PlayerHit();
        }
    }
}