using System;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject openDoorText;
    private bool playerIsNear = false;
    
     void Start()
    {
        openDoorText.SetActive(false);
    }
     
    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Player pressed E to open the door");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = true;
            openDoorText.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsNear = false;
            openDoorText.SetActive(false);
        }
    }
}
