using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    [SerializeField]
    AbstractTile currentTile;
    [SerializeField]
    BaseTile nextDestination;

    MoveDirection moveDirection;

    [SerializeField]
    TileGenerator tiles;


    // Start is called before the first frame update
    void Start()
    {
        currentTile = tiles[4, 7];
        transform.position = currentTile.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (nextDestination)
        //    if (currentTile != nextDestination)
        //    {
        //        Vector2 dir = nextDestination.transform.position - currentTile.transform.position;
        //        transform.Translate(dir.normalized * Time.deltaTime);
        //    }

        MoveNext();
    }

    void MoveNext()
    {
        AbstractTile nextTile;
        if (tiles[currentTile.TilePosition.x, currentTile.TilePosition.y + 1] is BaseTile)
        {
            nextTile = tiles[currentTile.TilePosition.x, currentTile.TilePosition.y + 1];
            transform.position = Vector2.MoveTowards(transform.position, nextTile.transform.position, 2f * Time.deltaTime);

            if(transform.position== nextTile.transform.position)
            {
                currentTile = nextTile;
            }
        }

    }

    //Vector2Int GetJunction()
    //{
    //    TileGenerator tileGenerator;

    //}

    enum MoveDirection
    {
        Left,
        Right,
        Up,
        Down
    }
}
