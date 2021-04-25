using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TileGenerator))]
public class TileManager : MonoBehaviour
{

   public AbstractTile[,] tileArray = new AbstractTile[Constants.RowCount, Constants.ColumnCount];
   public List<BaseTile> BaseTileList = new List<BaseTile>();

   public TileGenerator TileFactory;

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

   // Start is called before the first frame update
   void Awake()
   {
      TileFactory = GetComponent<TileGenerator>();
      TileFactory.GenerateBorder();
      (BaseTileList, tileArray) = TileFactory.GenerateTiles();
   }

   // Update is called once per frame
   void Update()
   {

   }
}
