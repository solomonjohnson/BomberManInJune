using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTile : MonoBehaviour
{
   private void OnTriggerStay2D(Collider2D collision)
   {
      if (collision.gameObject.CompareTag("Player"))
         UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(1);
         UnityEngine.SceneManagement.SceneManager.LoadScene(0);

      if (collision.gameObject.CompareTag("Enemy"))
      {
         Destroy(collision.gameObject);
      }
   }
}
