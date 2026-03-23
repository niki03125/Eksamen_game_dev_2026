using System;
using UnityEngine;

public class SpecialBook : MonoBehaviour
{
    [SerializeField] private GameObject importantEffectObject;
    private GameObject ghost;
    
    private bool bookOnFloor = false;
    private bool playerNearby = false;
    public GameObject winTextObject;

    private void Start()
    {
        winTextObject.SetActive(false);
        ghost = GameObject.FindWithTag("Ghost");
        if (importantEffectObject != null)
        {
            importantEffectObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (bookOnFloor && playerNearby && Input.GetKeyDown(KeyCode.R))
        {
            if (ghost != null)
            {
                Destroy(ghost);
                winTextObject.SetActive(true);
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
