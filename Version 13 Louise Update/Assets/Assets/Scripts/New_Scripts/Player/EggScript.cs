using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour
{
    //public float eggSpeed = 10f;
    private Transform player;
    Rigidbody2D rb;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroySelf());

    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Platform")) /*|| col.gameObject.CompareTag("MovingPlatform"))*/
        {
            player.position = transform.position;
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "Trap" || other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);

        }
        else
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

    }

}
