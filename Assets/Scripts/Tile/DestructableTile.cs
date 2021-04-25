using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableTile : AbstractTile
{
   [SerializeField] ExplosionTile explosionTile;

   public override void ExplodTile(TileManager tiles)
   {
      StartCoroutine(ExplosionCouroutine(tiles));
   }


   IEnumerator ExplosionCouroutine(TileManager tiles)
   {
      explosionTile.gameObject.SetActive(true);
      yield return new WaitForSeconds(4f);
      explosionTile.gameObject.SetActive(false);
      tiles.TileFactory.CreateBaseTileAtPos(this, tiles);
      Destroy(this.gameObject);
   }
}
