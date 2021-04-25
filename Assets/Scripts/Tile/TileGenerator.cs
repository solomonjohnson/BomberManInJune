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


   public AbstractTile[,] tileArray = new AbstractTile[Constants.RowCount, Constants.ColumnCount];
   public List<BaseTile> BaseTileList = new List<BaseTile>();

   public AbstractTile this[int row, int column]
   {
      get
      {
         try
         {
            return tileArray[row, column];
         }
         catch (System.Exception ex)
         {
            throw ex;
         }
      }
      set
      {
         tileArray[row, column] = value;
      }
   }

   public void CreateLevel()
   {
      GenerateBorder();
      GenerateTiles();
   }

   private void GenerateBorder()
   {
      GameObject obj;
      for (int i = 0; i < Constants.ColumnCount+1; i++)
      {
         obj = Instantiate(BlockTilePrefab, transform);
         obj.transform.position = new Vector2(i, 1);

         obj = Instantiate(BlockTilePrefab, transform);
         obj.transform.position = new Vector2(i-1, -Constants.ColumnCount);

      }

      for (int i = 0; i < Constants.RowCount+1; i++)
      {
         obj = Instantiate(BlockTilePrefab, transform);
         obj.transform.position = new Vector2(Constants.RowCount, -i);

         obj = Instantiate(BlockTilePrefab, transform);
         obj.transform.position = new Vector2(-1, -i+1);
      }
   }

   void GenerateTiles()
   {
      GameObject gameObject;
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
                  BaseTileList.Add(gameObject.GetComponent<BaseTile>());
               }
               else
                  gameObject = Instantiate(DestructableTilePrefab, transform);
            }
            gameObject.transform.position = new Vector2(j, -i);
            gameObject.GetComponent<AbstractTile>().TilePosition = new Vector2Int(i, j);
            tileArray[i, j] = gameObject.GetComponent<AbstractTile>();
         }

      transform.position = new Vector2(-Constants.ColumnCount / 2 + 0.5f, Constants.RowCount / 2 - 0.5f);
   }
}