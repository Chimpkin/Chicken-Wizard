using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float range, timeBTWShots, ShootSpeed;
    private float distToPlayer;
    public Transform player;
    public Transform shootPos;
    public Transform snake;
    public bool canShoot;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        canShoot=true;
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        
        if(distToPlayer <= range)
        { 
            if(player.position.x > transform.localScale.x && transform.localScale.x < 0
            || player.position.x < transform.localScale.x && transform.localScale.x > 0)

            {
                Flip();
            }

            if (canShoot) 
            {
               StartCoroutine(Shoot());
            }
        }
    }

    void Flip()
    {
        transform.rotation = Quaternion.Inverse(snake.rotation);
    }

    IEnumerator Shoot()
    {
        //Shoot
        canShoot = false;
        // time til next shot
        yield return new WaitForSeconds(timeBTWShots);
        //make a bullet
        GameObject NewProjectile = Instantiate(projectile, shootPos.position, Quaternion.identity);
        //velocity of bullet
        NewProjectile.GetComponent<Rigidbody2D>().velocity =new Vector2(-100f * ShootSpeed * Time.fixedDeltaTime,1f); 
        //if it can shoot again or not
        canShoot = true;
    }
}
