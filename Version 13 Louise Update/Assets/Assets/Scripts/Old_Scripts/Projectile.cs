using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float dieTime, damage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (CountdownTimer());
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Die();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CountdownTimer()
    {
        yield return new WaitForSeconds(dieTime);
        Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
