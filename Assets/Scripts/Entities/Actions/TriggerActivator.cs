using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    [SerializeField] private GameObject objectToActivate; // Reference to the object to activate when triggered

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Change "Player" to the tag of the object you want to trigger the activation
        {
            objectToActivate.SetActive(true); // Activate the object
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Change "Player" to the tag of the object you want to trigger the activation
        {
            objectToActivate.SetActive(false); // Activate the object
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Change "Player" to the tag of the object you want to trigger the activation
        {
            other.gameObject.GetComponent<Player>().DoAction(other);
            objectToActivate.SetActive(true); // Activate the object
        }
    }
}
