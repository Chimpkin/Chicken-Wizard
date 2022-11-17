using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleUI : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    public bool chase = false;
    public bool start;
    Rigidbody2D rb;
    public Transform player;
    public Transform startPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
       
       
    }
    // Update is called once per frame
    void Update()
    {
        
         if (transform.position == startPosition.transform.position)
        {
            start = true;
            animator.SetBool("IsChasing", false);
        }
        else
        {
            start = false;
            animator.SetBool("IsChasing", true); 
        }
        if (player == null)
        {
            return;
        }
        if (chase == true)
        {
            Chase();
        }
        else
        {
            ReturnStartPosition();
        }

        
        

    }

    public void Chase()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        
    }
    
    public void ReturnStartPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPosition.transform.position, moveSpeed * Time.deltaTime);
       
    }
}