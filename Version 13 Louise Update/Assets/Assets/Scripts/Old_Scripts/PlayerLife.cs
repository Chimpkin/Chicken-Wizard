using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{

   private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.CompareTag("Enemy"))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }*/

    }
}