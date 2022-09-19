using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleChase : MonoBehaviour
{
   public EagleUI[] eagleArray;

   private void OnTriggerEnter2D(Collider2D collision)
   {
        if(collision.CompareTag("Player"))
        {
            foreach (EagleUI eagle in eagleArray)
            {
                eagle.chase = true;
            }
        }
   }

   private void OnTriggerExit2D(Collider2D collision)
   {
        if(collision.CompareTag("Player"))
        {
            foreach (EagleUI eagle in eagleArray)
            {
                eagle.chase = false;
            }
        }
   }
}
