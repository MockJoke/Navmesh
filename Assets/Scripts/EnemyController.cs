using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private NavMeshAgent agent;

    void Awake()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");

        if (agent == null)
            agent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
    }
}
