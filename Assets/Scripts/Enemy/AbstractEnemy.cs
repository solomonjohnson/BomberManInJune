using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class AbstractEnemy : MonoBehaviour
{
   public BaseTile CurrentTile;

   [SerializeField]
   BaseTile nextDestination;

   public TileManager tiles;

   bool destReached = true;

   public EnemyManager EnemyManager;

   // Start is called before the first frame update
   void Start()
   {
      transform.position = CurrentTile.transform.position;
   }

   // Update is called once per frame
   void Update()
   {
      if (destReached)
         GetNextTile();
      else
         MoveToNext(nextDestination);
   }

   private void MoveToNext(BaseTile tile)
   {
      transform.position = Vector2.MoveTowards(transform.position, tile.transform.position, 2f * Time.deltaTime);

      if (transform.position == nextDestination.transform.position)
      {
         CurrentTile = tile;
         destReached = true;
      }
   }

   private void GetNextTile()
   {
      if (UnityEngine.Random.Range(0, 100) > 50)
         return;

      if (CurrentTile.IsJunction(tiles))
      {
         List<BaseTile> junctionTiles = CurrentTile.GetJunction(tiles);
         nextDestination = junctionTiles[UnityEngine.Random.Range(0, junctionTiles.Count)];
         destReached = false;
      }
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
      //if
   }
}
