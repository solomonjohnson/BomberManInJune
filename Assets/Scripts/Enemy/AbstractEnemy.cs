using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class AbstractEnemy : MonoBehaviour
{
   [SerializeField]
   BaseTile currentTile;

   [SerializeField]
   BaseTile nextDestination;


   [SerializeField]
   TileManager tiles;

   bool destReached = true;

   // Start is called before the first frame update
   void Start()
   {
      currentTile = tiles.BaseTileList[0];
      transform.position = currentTile.transform.position;
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
         currentTile = tile;
         destReached = true;
      }
   }

   private void GetNextTile()
   {
      if (UnityEngine.Random.Range(0, 100) > 50)
         return;

      if(currentTile.IsJunction(tiles))
      {
         List<BaseTile> junctionTiles = currentTile.GetJunction(tiles);
         nextDestination = junctionTiles[UnityEngine.Random.Range(0, junctionTiles.Count)];
         destReached = false; 
      }
   }
}
