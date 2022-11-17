using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMove : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public float offsetSmoothing;
    private Vector3 playerPosition;
    public Vector3 minValues, MaxValues;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        //Camera follow the player
        playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        //If facing right, the camera moves a little further right. And furthur left if facing left
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }

        //Establish Camera Border
        Vector3 borderPosition = new Vector3(
            Mathf.Clamp(playerPosition.x, minValues.x, MaxValues.x),
            Mathf.Clamp(playerPosition.y, minValues.y, MaxValues.y),
            Mathf.Clamp(playerPosition.z, minValues.z, MaxValues.z));

        //camera smoothly catches up to player with a slight delay
        transform.position = Vector3.Lerp(transform.position, borderPosition, offsetSmoothing * Time.deltaTime);
    }
}
