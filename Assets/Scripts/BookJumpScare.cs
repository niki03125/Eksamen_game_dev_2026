using UnityEngine;

public class BookJumpScare : MonoBehaviour
{
    public Rigidbody bookRb;

    private AudioSource bookSound;
    private bool triggered = false;

    private void Start()
    {
        bookSound = bookRb.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            bookRb.isKinematic = false;
            
        }
    }
}