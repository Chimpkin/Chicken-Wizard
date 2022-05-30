using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScriptNew : MonoBehaviour
{
    public float power = 10f;
    //public Rigidbody2D rb;

    public GameObject egg;

    TrajectoryLine tl;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera camMain;
    Vector2 force;
    Vector3 startPos;
    Vector3 endPos;

    private void Start()
    {
        camMain = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update()
    {
        //Vector2 startPosition = transform.position;
        //Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 direction = mousePosition - startPosition;
        //transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            startPos = camMain.ScreenToWorldPoint(Input.mousePosition);
            startPos.z = 15;
            Debug.Log(startPos);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = camMain.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            tl.RenderLine(startPos, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = camMain.ScreenToWorldPoint(Input.mousePosition);
            endPos.z = 15;

            force = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minPower.x, maxPower.x), Mathf.Clamp(startPos.y - endPos.y, minPower.y, maxPower.y));
            /*rb.AddForce(force * power, ForceMode2D.Impulse);*/
            GameObject newEgg = Instantiate(egg, null);
            newEgg.transform.position = this.transform.position;
            newEgg.GetComponent<Rigidbody2D>().AddForce(force * power, ForceMode2D.Impulse);

            tl.EndLine();
        }

    }



}
