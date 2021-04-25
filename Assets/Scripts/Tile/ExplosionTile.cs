using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTile : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
         Debug.Log("Player collided");

      if (collision.gameObject.CompareTag("Enemy"))
         Destroy(collision.gameObject);
   }
}
