using UnityEngine;
using UnityEngine.AI;

public class GhostNPC : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 15f;
    
    [SerializeField] public float dmgDistance = 2f; // Distancen hvor spøgelset kan røre dig
    [SerializeField] public float damageAmount = 10f;
    [SerializeField] public float attackSpeed = 1.5f; // Hvor mange sekunder der går mellem hvert slag
    
    public float roamRadius = 20f;
    public float roamTimer = 5f;

    private float timer;
    private float attackTimer; // Holder styr på cooldown
    private NavMeshAgent agent;
    private Animator animator;
    private PlayerHealth playerHealth; // Reference til spillerens liv
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        timer = roamTimer;

        // Find PlayerHealth scriptet på spilleren
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (player == null || playerHealth == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseDistance)
        {
            agent.SetDestination(player.position);
            
            if (animator != null) animator.SetBool("isChasing", true);
            
            if (distance <= dmgDistance)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackSpeed)
                {
                    AttackPlayer();
                    attackTimer = 0f; // Reset cooldown
                }
            }
        }
        else
        {
            // Roaming logik
            timer += Time.deltaTime;
            if(timer >= roamTimer)
            {
                agent.SetDestination(RandomNavSphere(transform.position, roamRadius));
                timer = 0f;
            }
            
            if(animator != null) animator.SetBool("isChasing", false);
        }
    }

    void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
            Debug.Log("Ghost angreb spilleren!");
            
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