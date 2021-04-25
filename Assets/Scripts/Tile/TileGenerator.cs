using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
   [SerializeField]
   GameObject baseTilePrefab;

   [SerializeField]
   GameObject BlockTilePrefab;

   [SerializeField]
   GameObject DestructableTilePrefab;


   public void GenerateBorder()
   {
      GameObject obj;
      for (int i = 0; i < Constants.ColumnCount + 1; i++)
      {
         obj = Instantiate(BlockTilePrefab, transform);
         obj.transform.position = new Vector2(i, 1);

         obj = Instantiate(BlockTilePrefab, transform);
         obj.transform.position = new Vector2(i - 1, -Constants.RowCount);

      }

      for (int i = 0; i < Constants.RowCount + 1; i++)
      {
         obj = Instantiate(BlockTilePrefab, transform);
         obj.transform.position = new Vector2(Constants.ColumnCount, -i);

         obj = Instantiate(BlockTilePrefab, transform);
         obj.transform.position = new Vector2(-1, -i + 1);
      }
   }

   public (List<BaseTile> baseTiles, AbstractTile[,] tiles) GenerateTiles()
   {
      GameObject gameObject;
      TileManager manager = new TileManager();

      for (int i = 0; i < Constants.RowCount; i++)
         for (int j = 0; j < Constants.ColumnCount; j++)
         {
            if (i % 2 != 0 && j % 2 != 0)
            {
               gameObject = Instantiate(BlockTilePrefab, transform);
            }
            else
            {
               if (UnityEngine.Random.Range(0, 100) < 80)
               {
                  gameObject = Instantiate(baseTilePrefab, transform);
                  manager.BaseTileList.Add(gameObject.GetComponent<BaseTile>());
               }
               else
                  gameObject = Instantiate(DestructableTilePrefab, transform);
            }
            gameObject.transform.position = new Vector2(j, -i);
            gameObject.GetComponent<AbstractTile>().TilePosition = new Vector2Int(i, j);
           manager.tileArray[i, j] = gameObject.GetComponent<AbstractTile>();
         }

      transform.position = new Vector2(-Constants.ColumnCount / 2 + 0.5f, Constants.RowCount / 2 - 0.5f);
      return (manager.BaseTileList, manager.tileArray);
   }

   public void CreateBaseTileAtPos(AbstractTile t, TileManager manager)
   {
      GameObject obj = Instantiate(baseTilePrefab, transform) ;
      obj.transform.position = t.transform.position;
      manager.tileArray[t.TilePosition.x, t.TilePosition.y] = obj.GetComponent<AbstractTile>();
      manager.BaseTileList.Add(obj.GetComponent<BaseTile>());
      obj.GetComponent<AbstractTile>().TilePosition = t.TilePosition;
   }
}