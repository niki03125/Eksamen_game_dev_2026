using UnityEngine;

public class BookImpactSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public ParticleSystem dustEffect;
    [SerializeField] private bool hasPlayed = false;

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
            
            if (dustEffect != null)
            {
                dustEffect.Play();
            }
        }
    }
}