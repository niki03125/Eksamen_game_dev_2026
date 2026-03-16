using UnityEngine;
using UnityEngine.AI;

public class GhostNPC : MonoBehaviour
{

    public Transform player;
    public float chaseDistance = 15f;
    
    public float roamRadius = 20f;
    public float roamTimer = 5f;

    private float timer;
    private NavMeshAgent agent;
    private Animator animator;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        timer = roamTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        Vector3 ghostPos = transform.position; ghostPos.y = 0;
        Vector3 playerPos = player.position; playerPos.y = 0;
        float distance = Vector3.Distance(ghostPos, playerPos);

        if (distance < chaseDistance)
        {
            agent.SetDestination(player.position);
            if (animator != null)
                animator.SetBool("isChasing", true);
        }
        else
        {
            timer += Time.deltaTime;
            if(timer >= roamTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, roamRadius);
                agent.SetDestination(newPos);
                timer = 0f;
            }
            
            if(animator != null)
                animator.SetBool("isChasing", false);
        }
    }

    Vector3 RandomNavSphere(Vector3 origin, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance + origin;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, distance, -1);
        return navHit.position;
    }
}
