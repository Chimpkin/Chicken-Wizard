using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeUI : MonoBehaviour
{
    public float range, timeBTWShots, ShootSpeed;
    private float distToPlayer;
    public Transform player;
    public Transform shootPos;
    public Transform snake;
    public bool canShoot;
    public GameObject projectile;
    public Animator animator;
   


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        canShoot =true;
        
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        //animator.SetBool("IsShooting", false);
        if(distToPlayer <= range)
        {
   

            if (canShoot)
            {
                StartCoroutine(Shoot());
                animator.SetBool("IsShooting", true);
            }
            
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }
       
    }


    IEnumerator Shoot()
    {
        //Shoot
        canShoot = false;
        // time til next shot
        yield return new WaitForSeconds(timeBTWShots);
        //make a bullet
        Instantiate(projectile, shootPos.position, Quaternion.identity); 
        //if it can shoot again or not
        canShoot = true;
    }
}
