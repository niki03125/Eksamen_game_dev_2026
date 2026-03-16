using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ThrowBall : MonoBehaviour
{
    [SerializeField] private float throwForce = 10f;
    [SerializeField] private float interactDistance = 3f; // Hvor tæt skal man være?
    
    private Rigidbody rb;
    private Camera playerCamera;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckIfLookingAtBall();
        }
    }
    
    void CheckIfLookingAtBall()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                ThrowBallAction();
                BlowUpBall();
            }
        }
    }

    void ThrowBallAction()
    {
        Vector3 direction = playerCamera.transform.forward + Vector3.up * 1f;
        rb.AddForce(direction * throwForce, ForceMode.Impulse);
    }

    void BlowUpBall()
    {
        int tal = Random.Range(1, 6);
        Debug.Log(tal);
        if (tal == 1)
        {
            Destroy(gameObject, 1.5f);
            Invoke("PlaySound", 1.49f);
        }
    }

    void PlaySound()
    {
        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
    }
}