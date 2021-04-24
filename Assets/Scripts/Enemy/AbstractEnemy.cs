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

   [SerializeField] MoveDirection moveDirection = MoveDirection.Right;

   [SerializeField]
   TileGenerator tiles;


   // Start is called before the first frame update
   void Start()
   {
      currentTile = tiles.BaseTileList[0];
      transform.position = currentTile.transform.position;
   }

   // Update is called once per frame
   void Update()
   {
         MoveToDirection(moveDirection);
   }

   private void MoveToDirection(MoveDirection direction)
   {
      AbstractTile nextTile = currentTile;
      switch (direction)
      {
         case MoveDirection.Left:
            if (!(currentTile.TilePosition.y - 1 < 0))
               nextTile = tiles[currentTile.TilePosition.x, currentTile.TilePosition.y - 1];
            MoveNext(nextTile);
            break;
         case MoveDirection.Right:
            if (!(currentTile.TilePosition.y + 1 >= Constants.RowCount))
               nextTile = tiles[currentTile.TilePosition.x, currentTile.TilePosition.y + 1];
            MoveNext(nextTile);
            break;
         case MoveDirection.Up:
            if (!(currentTile.TilePosition.x - 1 < 0))
               nextTile = tiles[currentTile.TilePosition.x - 1, currentTile.TilePosition.y];
            MoveNext(nextTile);
            break;
         case MoveDirection.Down:
            if (!(currentTile.TilePosition.x + 1 >= Constants.ColumnCount))
               nextTile = tiles[currentTile.TilePosition.x + 1, currentTile.TilePosition.y];
            MoveNext(nextTile);
            break;
         default:
            break;
      }

   }

   void MoveNext(AbstractTile nextTile)
   {
      if (nextTile is BaseTile)
      {
         transform.position = Vector2.MoveTowards(transform.position, nextTile.transform.position, 2f * Time.deltaTime);

         if (transform.position == nextTile.transform.position)
         {
            currentTile = nextTile as BaseTile;

            if (currentTile.IsJunction(tiles))
               ChangeToRandomDirection();
         }
      }
      else
      {
         switch (moveDirection)
         {
            case MoveDirection.Left:
               moveDirection = MoveDirection.Right;
               break;
            case MoveDirection.Right:
               moveDirection = MoveDirection.Left;
               break;
            case MoveDirection.Up:
               moveDirection = MoveDirection.Down;
               break;
            case MoveDirection.Down:
               moveDirection = MoveDirection.Up;
               break;
            default:
               break;
         }
      }
   }


   void ChangeToRandomDirection()
   {
      if (currentTile.IsJunction(tiles))
      {
         if (UnityEngine.Random.Range(0, 100) > 50)
            return;

         moveDirection = (MoveDirection)UnityEngine.Random.Range(0, 3);

      }
   }

   enum MoveDirection
   {
      Left,
      Right,
      Up,
      Down
   }

}
