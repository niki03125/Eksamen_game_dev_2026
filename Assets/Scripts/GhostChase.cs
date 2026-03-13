using UnityEngine;

public class GhostChase : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 10f;

    UnityEngine.AI.NavMeshAgent agent;
    Animator animator;
    
    
    void start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        
        if(distance < chaseDistance)
        {
            agent.SetDestination(player.position);
            animator.SetBool("isChasing", true);
        }
        else
        {
            animator.SetBool("isChasing", false);
        }
    }
}
