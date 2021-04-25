using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTile : MonoBehaviour
{
   public Vector2Int TilePosition;

   public abstract void ExplodTile(TileManager tiles);

}
