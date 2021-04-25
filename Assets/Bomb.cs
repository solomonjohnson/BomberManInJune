using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
   public BombController BombController;
   public BaseTile CurrentTile;
   // Start is called before the first frame update
   void OnEnable()
   {
      //CurrentTile.GetCrossTiles(3,controller.ma);
      Invoke(nameof(ExplodeBomb), 5f);
   }

   void ExplodeBomb()
   {
      BombController.bombActive = false;
      var list = CurrentTile.GetCrossTiles(3, BombController.manager);
      foreach (var item in list)
      {
         item.ExplodTile(BombController.manager);
      }
      //controller.bombExploded?.Invoke(this, CurrentTile);
      Destroy(this.gameObject);
   }
}
