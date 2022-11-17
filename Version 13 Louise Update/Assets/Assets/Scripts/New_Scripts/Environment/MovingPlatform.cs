using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pos01, pos02;
    public Transform startPos;
    public float moveSpeed;

    Vector3 nextPos;

    void Start()
    {
        nextPos = startPos.position;
    }


    void Update()
    {
        if (transform.position == pos01.position)
        {
            nextPos = pos02.position;
        }
        else if (transform.position == pos02.position)
        {
            nextPos = pos01.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);

    }

}
