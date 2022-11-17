using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScriptNew : MonoBehaviour
{
    public float power;
    //public Rigidbody2D rb;

    public GameObject egg;

    TrajectoryLine tl;

    public float minPower = -10;
    public float maxPower = 10;

    Camera camMain;
    Vector2 force;
    Vector2 startPos;
    Vector2 endPos;

    private void Start()
    {
        camMain = Camera.main;
        tl = GetComponent<TrajectoryLine>();
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            startPos = camMain.ScreenToWorldPoint(Input.mousePosition);
            /*startPos.z = 20;*/
            Debug.Log(startPos);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 currentPoint = camMain.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 20;
            tl.RenderLine(startPos, currentPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = camMain.ScreenToWorldPoint(Input.mousePosition);
            /*endPos.z = 20;*/

            Vector2 _velocity = power * CalculateForce(startPos, endPos);

            GameObject newEgg = Instantiate(egg, null);
            newEgg.transform.position = this.transform.position;
            newEgg.GetComponent<Rigidbody2D>().velocity = _velocity;

            tl.EndLine();

            /*force = new Vector2(Mathf.Clamp(startPos.x - endPos.x, minPower.x, maxPower.x), Mathf.Clamp(startPos.y - endPos.y, minPower.y, maxPower.y));
            /*rb.AddForce(force * power, ForceMode2D.Impulse);
            GameObject newEgg = Instantiate(egg, null);
            newEgg.transform.position = this.transform.position;
            newEgg.GetComponent<Rigidbody2D>().AddForce(force * power, ForceMode2D.Impulse);*/
        }

    }

    private Vector2 CalculateForce(Vector2 beginPoint, Vector2 endPoint)
    {
        Vector2 difference = beginPoint - endPoint;
        float vectorPower = difference.magnitude;
        vectorPower = Mathf.Clamp(vectorPower, minPower, maxPower);
        return difference.normalized * vectorPower;
    }



}
