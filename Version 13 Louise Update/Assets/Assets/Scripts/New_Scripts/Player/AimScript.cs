using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    [SerializeField] GameObject egg;

    public GameUI gameUi;
    public float startForce;
    public Transform firePoint;
    public int shotsFired = 0;
    public int numberOfShots = 1;

    public GameObject point;
    GameObject[] points;
    public int numOfPoints;
    public float spaceBetweenPoints;
    Vector2 direction;

    void Start()
    {
        points = new GameObject[numOfPoints];
        for (int i = 0; i < numOfPoints; i++)
        {
            points[i] = Instantiate(point, firePoint.position, Quaternion.identity);
        }
    }

    void Update()
    {
        Vector2 startPos = transform.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - startPos;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0) && GameObject.FindGameObjectWithTag("Egg") == null && gameUi.gameIsPaused == false)
        {
            StartCoroutine(Noclimb());
        }

        for (int i = 0; i < numOfPoints; i++)
        {
            points[i].transform.position = PointPos(i * spaceBetweenPoints);
        }

    }

    void Shoot()
    {
        Debug.Log("Shots Fired!!");
        GameObject newEgg = Instantiate(egg, firePoint.position, firePoint.rotation);
        newEgg.GetComponent<Rigidbody2D>().velocity = transform.right * startForce;
        shotsFired++;
    }


    Vector2 PointPos(float t)
    {
        Vector2 position = (Vector2)firePoint.position + (direction.normalized * startForce * t) + 1f * Physics2D.gravity * (t * t);
        return position;
    }

    IEnumerator Noclimb()
    {
        yield return new WaitForSeconds(0.1f);

        Shoot();
    }


       
    }
