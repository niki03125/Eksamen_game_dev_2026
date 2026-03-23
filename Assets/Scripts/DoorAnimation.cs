using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public float distance = 3f;

    private bool isOpen = false;
    
    

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist < distance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("E was pressed");
                isOpen = !isOpen;
                animator.SetBool("Open", isOpen);
            }
        }
    }
}
