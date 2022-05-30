using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float dieTime = 2f;
    public float speed;
    public Transform player;
    Rigidbody2D rb;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        moveDirection = (player.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        
        Destroy(gameObject, dieTime);
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Platform") || col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
       //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        //if(transform.position.x == target.x && transform.position.y == target.y)
        //{
            //Destroy(gameObject);
        //}
           

    }

}