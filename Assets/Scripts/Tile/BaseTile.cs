using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : AbstractTile
{

   public bool IsJunction(TileGenerator tiles)
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

   public List<BaseTile> GetJunction(TileGenerator tiles)
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
}

