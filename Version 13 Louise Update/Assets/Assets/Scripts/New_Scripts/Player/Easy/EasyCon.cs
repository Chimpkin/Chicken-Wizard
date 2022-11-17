using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyCon : MonoBehaviour
{
    public EasyPlay playerController;
    public int magic = 0;
    public float Grav;
    public AimScript aimScript;
    public EasyPlay PC;
    public GameObject Floater;
    public GameObject Force;
    public GameObject Door;
    public int option = 0;
    public int option1 = 0;

    IEnumerator Pickup(Collision2D collision, int time)
    {
        yield return new WaitForSeconds(time);

        PC.additionalJumps = 1;
        PC.jumpForce = 21;

        Floater.SetActive(true);

    }

    IEnumerator Pickup2(Collision2D collision, int time)
    {
        yield return new WaitForSeconds(time);

        aimScript.startForce = 13;

        Force.SetActive(true);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Door"))
        {
            Debug.Log("Work");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Collectable"))
        {
            magic++;

            playerController.health += 5;

            collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.CompareTag("Powerup"))
        {
            PC.additionalJumps = 3;
            PC.jumpForce = 20;

            collision.gameObject.SetActive(false);

            StartCoroutine(Pickup(collision, option));


        }


        if (collision.gameObject.CompareTag("Powerup2"))
        {
            aimScript.startForce = 40;

            collision.gameObject.SetActive(false);

            StartCoroutine(Pickup2(collision, option1));


        }
    }

    public void Update()
    {
        if (magic <= 4)
        {
            Door.SetActive(true);

        }

    }

}