using UnityEngine;

public class BookImpactSound : MonoBehaviour
{
    private AudioSource audioSource;
    private bool hasPlayed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!hasPlayed && collision.gameObject.CompareTag("libraryFloor"))
        {
            hasPlayed = true;
            audioSource.Play();
        }
    }
}