using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CutSeen : MonoBehaviour
{
    public Transform pos01, pos02, pos03, pos04, pos05;
    public Transform startPos;
    public float moveSpeed;
    Vector3 nextPos;
    public Camera CameraUno;
    void Start()
    {
        nextPos = startPos.position;
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("Work");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Update()
    {

        if (transform.position == pos01.position)
        {
            nextPos = pos02.position;
        }
        if (transform.position == pos02.position)
        {
            nextPos = pos03.position;
        }
        if (transform.position == pos03.position)
        {
            nextPos = pos04.position;
        }
        if (transform.position == pos04.position)
        {
            nextPos = pos05.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.CompareTag("Dir"))
        {
            StartCoroutine(Waiter());

        }

        if (collider.gameObject.CompareTag("Zoom"))
        {
            CameraUno.fieldOfView = 14f;
        }


        if (collider.gameObject.CompareTag("Fast"))
        {
            moveSpeed = 100;
        }
    }

        void OnTriggerExit2D(Collider2D collider)
        {

            if (collider.gameObject.CompareTag("Zoom"))
            {
                CameraUno.fieldOfView = 23f;
            }

            if (collider.gameObject.CompareTag("Fast"))
            {
            moveSpeed = 5;
            }
    }
    }


