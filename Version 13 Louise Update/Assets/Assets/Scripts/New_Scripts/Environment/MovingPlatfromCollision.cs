using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatfromCollision : MonoBehaviour
{
    public GameObject player;

    void start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            Debug.Log("Collided");
            player.transform.parent = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            player.transform.parent = null;
        }
    }
}
