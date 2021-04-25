using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : AbstractTile
{

   [SerializeField] ExplosionTile explosionTile;

   public bool IsJunction(TileManager tiles)
   {
      int i = 0;
      if (TilePosition.x + 1 < Constants.RowCount)
         if (tiles[TilePosition.x + 1, TilePosition.y] is BaseTile) i++; ;

      if (TilePosition.x - 1 >= 0)
         if (tiles[TilePosition.x - 1, TilePosition.y] is BaseTile) i++; ;

      if (TilePosition.y + 1 < Constants.ColumnCount)
         if (tiles[TilePosition.x, TilePosition.y + 1] is BaseTile) i++;

      if (TilePosition.y - 1 >= 0)
         if (tiles[TilePosition.x, TilePosition.y - 1] is BaseTile) i++;

      return i > 0;
   }

   public List<BaseTile> GetJunction(TileManager tiles)
   {
      List<BaseTile> tilesList = new List<BaseTile>();

      if (TilePosition.x + 1 < Constants.RowCount)
         if (tiles[TilePosition.x + 1, TilePosition.y] is BaseTile) tilesList.Add(tiles[TilePosition.x + 1, TilePosition.y] as BaseTile);

      if (TilePosition.x - 1 >= 0)
         if (tiles[TilePosition.x - 1, TilePosition.y] is BaseTile) tilesList.Add(tiles[TilePosition.x - 1, TilePosition.y] as BaseTile);

      if (TilePosition.y + 1 < Constants.ColumnCount)
         if (tiles[TilePosition.x, TilePosition.y + 1] is BaseTile) tilesList.Add(tiles[TilePosition.x, TilePosition.y + 1] as BaseTile);

      if (TilePosition.y - 1 >= 0)
         if (tiles[TilePosition.x, TilePosition.y - 1] is BaseTile) tilesList.Add(tiles[TilePosition.x, TilePosition.y - 1] as BaseTile);

      return tilesList;
   }

   public List<AbstractTile> GetCrossTiles(int count, TileManager tiles)
   {
      List<AbstractTile> tilesList = new List<AbstractTile>();

      if (TilePosition.x + 1 < Constants.RowCount)
         tilesList.Add(tiles[TilePosition.x + 1, TilePosition.y]);

      if (TilePosition.x - 1 >= 0)
         tilesList.Add(tiles[TilePosition.x - 1, TilePosition.y]);

      if (TilePosition.y + 1 < Constants.ColumnCount)
         tilesList.Add(tiles[TilePosition.x, TilePosition.y + 1]);

      if (TilePosition.y - 1 >= 0)
         tilesList.Add(tiles[TilePosition.x, TilePosition.y - 1]);

      tilesList.RemoveAll(x => x is BlockTile);
      tilesList.Add(this);

      return tilesList;
   }

   public override void ExplodTile(TileManager tiles)
   {
      StartCoroutine(ExplosionCouroutine());
   }

   IEnumerator ExplosionCouroutine()
   {
      explosionTile.gameObject.SetActive(true);
      yield return new WaitForSeconds(2f);
      explosionTile.gameObject.SetActive(false);
   }
}

