using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField]
    GameObject tilePrefab;

    [SerializeField]
    Sprite sprite;

    float tileOffset = 10f;

    public GameObject[,] tileArray = new GameObject[Constants.RowCount, Constants.ColumnCount];


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void CreateLevel()
    {
        GenerateTiles();
        SetBlockades();
    }
    void GenerateTiles()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector2 nextPosition = pos;
        GameObject gameObject;
        Sprite s = tilePrefab.GetComponent<SpriteRenderer>().sprite;
        for (int i = 0; i < Constants.RowCount; i++)
            for (int j = 0; j < Constants.ColumnCount; j++)
            {
                gameObject = Instantiate(tilePrefab, transform);
                gameObject.transform.position = new Vector2(j, -i);
                tileArray[i, j] = gameObject;
            }

        transform.position = new Vector2(-Constants.ColumnCount / 2 + 0.5f, Constants.RowCount / 2 - 0.5f);
    }

    void SetBlockades()
    {
        for (int i = 0; i < Constants.RowCount; i++)
            for (int j = 0; j < Constants.ColumnCount; j++)
            {
                if(i%2!=0 && j%2!=0)
                {
                    tileArray[i, j].GetComponent<SpriteRenderer>().sprite = sprite;
                    tileArray[i, j].GetComponent<Collider2D>().isTrigger = false;
                }
            }
    }


}