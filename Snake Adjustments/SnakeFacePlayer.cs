using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeFacePlayer : MonoBehaviour
{
    bool isFacingRight;
    public Transform player;
   

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    public void Update()
    {
      
        if (player.position.x > transform.position.x)
        {
            if (!isFacingRight)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                isFacingRight = true;
            }
        }
        else if (player.position.x < transform.position.x)
        {
            if (isFacingRight)
            {
                 transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                 isFacingRight = false;
            }
        }
    }

}

