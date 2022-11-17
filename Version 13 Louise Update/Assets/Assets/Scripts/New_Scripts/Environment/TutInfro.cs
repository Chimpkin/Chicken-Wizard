using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutInfro : MonoBehaviour
{
    public GameObject Text; 

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Text.SetActive(true);


        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Text.SetActive(false);


        }
    }
}
