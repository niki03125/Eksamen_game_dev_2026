using UnityEngine;
using UnityEngine.AI;

public class GhostNPC : MonoBehaviour
{
    public float roamRadius = 20f;
    public float roamTimer = 5f;

    private float timer;
    private NavMeshAgent agent;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = roamTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= roamTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, roamRadius);
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, -1);
        
        return navHit.position;
    }
}
