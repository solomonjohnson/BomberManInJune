using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTile : AbstractTile
{
    public bool IsJunction(TileGenerator tiles)
    {
        return tiles[TilePosition.x + 1, TilePosition.y] is BaseTile ||
        tiles[TilePosition.x + 1, TilePosition.y] is BaseTile ||
        tiles[TilePosition.x + 1, TilePosition.y] is BaseTile ||
        tiles[TilePosition.x + 1, TilePosition.y] is BaseTile;
    }
}
