using System;
using UnityEngine;

public class SpecialBook : MonoBehaviour
{
    [SerializeField] private GameObject importantEffectObject;
    [SerializeField] private GameObject Ghost;
    
    private bool bookOnFloor = false;
    private bool playerNearby = false;

    private void Start()
    {
        if (importantEffectObject != null)
        {
            importantEffectObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (bookOnFloor && Input.GetKeyDown(KeyCode.R))
        {
            if (Ghost != null)
            {
                Destroy(Ghost);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("libraryFloor"))
        {
            bookOnFloor = true;
            if (importantEffectObject != null)
            {
                importantEffectObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
