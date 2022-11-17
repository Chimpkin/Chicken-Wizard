using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowFall : MonoBehaviour
{

    public KeyCode leaf;
    public Transform wings;
    public float fallSpeed;
    public bool floating;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().drag = fallSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leaf))
        {
            Debug.Log("help");
            floating = true;
            GetComponent<Rigidbody2D>().drag = fallSpeed = 12;
        }
        else
        {
            floating = false;
            GetComponent<Rigidbody2D>().drag = fallSpeed = 0;
        }
    }


}