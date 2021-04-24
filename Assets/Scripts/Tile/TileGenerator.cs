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
    GenerateTiles();
    GenerateDestructableTiles(5);
  }

  private void GenerateDestructableTiles(int numDestrct)
  {
    GameObject gameObject;
    AbstractTile randomTile;
    for (int i = 0; i < numDestrct; i++)
    {
      randomTile = tileArray[UnityEngine.Random.Range(0, Constants.RowCount), UnityEngine.Random.Range(0, Constants.ColumnCount)];
      if (randomTile is BaseTile)
      {
        var tile = (BaseTile)randomTile;
        gameObject = Instantiate(DestructableTilePrefab, transform);
        gameObject.transform.position = randomTile.transform.position;
        tile.destructableTile = gameObject.GetComponent<DestructableTile>();
      }
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
          gameObject = Instantiate(baseTilePrefab, transform);
          BaseTileList.Add(gameObject.GetComponent<BaseTile>());
        }
        gameObject.transform.position = new Vector2(j, -i);
        gameObject.GetComponent<AbstractTile>().TilePosition = new Vector2Int(i, j);
        tileArray[i, j] = gameObject.GetComponent<AbstractTile>();
      }

    transform.position = new Vector2(-Constants.ColumnCount / 2 + 0.5f, Constants.RowCount / 2 - 0.5f);
  }
}