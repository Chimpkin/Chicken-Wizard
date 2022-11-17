using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript_OLD : MonoBehaviour
{
    /*public GameObject bulletPrefab;
    public Transform firePoint;

    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float rotateY = 0f;

        if (mousePos.x < transform.position.x)
        {
            rotateY = 180f;
        }
        transform.eulerAngles = new Vector3(transform.rotation.x, rotateY, transform.rotation.z);


        if (Input.GetButtonDown("Fire1")) 
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Debug.Log("Shots Fired!!");
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Destroy(bullet, 5f);
    }*/
}
