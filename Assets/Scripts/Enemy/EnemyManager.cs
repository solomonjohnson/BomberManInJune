using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   [SerializeField]
   GameObject EnemyPrefab;

   [SerializeField]
   int numEnemy = 5;

   [SerializeField]
   TileManager tileManager;

   // Start is called before the first frame update
   void Start()
   {
      SpawnEnemies();
   }

   void SpawnEnemies()
   {
      GameObject obj;
      for (int i = 0; i < numEnemy; i++)
      {
         obj = Instantiate(EnemyPrefab, transform);
         obj.GetComponent<AbstractEnemy>().tiles = tileManager;
         var baseTile = tileManager.BaseTileList[Random.Range(0, tileManager.BaseTileList.Count)];
         obj.GetComponent<AbstractEnemy>().CurrentTile = baseTile;
      }
   }

}
