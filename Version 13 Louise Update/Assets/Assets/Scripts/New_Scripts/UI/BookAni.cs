using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAni : MonoBehaviour
{
    public GameObject Item;
    public float Time = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Ani());
    }

    // Update is called once per frame
 IEnumerator Ani()
    {
        yield return new WaitForSeconds(Time);

        

       Item.SetActive(true);

    }
}