using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   [SerializeField]
   GameObject BlueEnemyPrefab;

   [SerializeField]
   GameObject BrownEnemyPrefab;

   [SerializeField]
   int numBlueEnemy = 3;

   [SerializeField]
   int numBrownEnemy = 2;

   [SerializeField]
   TileManager tileManager;

   public List<AbstractEnemy> enemies = new List<AbstractEnemy>();

   // Start is called before the first frame update
   void Start()
   {
      SpawnEnemies();
   }

   void SpawnEnemies()
   {
      GameObject obj;
      for (int i = 0; i < numBlueEnemy; i++)
      {
         obj = Instantiate(BlueEnemyPrefab, transform);
         obj.GetComponent<AbstractEnemy>().tiles = tileManager;
         var baseTile = tileManager.BaseTileList[Random.Range(0, tileManager.BaseTileList.Count)];
         obj.GetComponent<AbstractEnemy>().CurrentTile = baseTile;
         enemies.Add(obj.GetComponent<AbstractEnemy>());
         obj.GetComponent<AbstractEnemy>().EnemyManager = this;
      }

      for (int i = 0; i < numBlueEnemy; i++)
      {
         obj = Instantiate(BrownEnemyPrefab, transform);
         obj.GetComponent<AbstractEnemy>().tiles = tileManager;
         var baseTile = tileManager.BaseTileList[Random.Range(0, tileManager.BaseTileList.Count)];
         obj.GetComponent<AbstractEnemy>().CurrentTile = baseTile;
         enemies.Add(obj.GetComponent<AbstractEnemy>());
         obj.GetComponent<AbstractEnemy>().EnemyManager = this;
      }
   }

}
