using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
   [SerializeField]
   TileManager tiles;


   [SerializeField]
   float speedFactor = 1f;



   [SerializeField]
   BombController bombController;

   private void Awake()
   {
      //tiles.CreateLevel();
      Vector2 positionSpawn = tiles.tileArray[0, 0].transform.position;
      SpawnPlayer(positionSpawn);
   }

   private void Update()
   {
      MovePlayer();
   }

   private void MovePlayer()
   {
      if (Input.GetKey(KeyCode.W))
         transform.Translate(Vector3.up * Time.deltaTime * speedFactor);
      else if (Input.GetKey(KeyCode.A))
         transform.Translate(Vector3.right * Time.deltaTime * -speedFactor);
      else if (Input.GetKey(KeyCode.S))
         transform.Translate(Vector3.up * Time.deltaTime * -speedFactor);
      else if (Input.GetKey(KeyCode.D))
         transform.Translate(Vector3.right * Time.deltaTime * speedFactor);
   }

   private void SpawnPlayer(Vector2 pos)
   {
      transform.position = pos;
   }

   //void MoveNextTile(float i, float j)
   //{
   //   Vector2 nextTilePos = tiles.tileArray[(int)i, (int)j].transform.position;

   //   if ((Vector2)transform.position != nextTilePos)
   //      transform.position = (Vector3)nextTilePos;

   //   currentTile = new Vector2(i, j);
   //}

   private void OnTriggerStay2D(Collider2D collision)
   {

      if (Input.GetKey(KeyCode.Space) && !bombController.bombActive)
      {
         bombController.bombActive = true;
         GameObject obj = Instantiate(bombController.bombObj, collision.transform);
         obj.GetComponent<Bomb>().BombController = bombController;
         obj.GetComponent<Bomb>().CurrentTile = collision.GetComponent<BaseTile>();
      }
   }

}
