using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    public GameObject tilePrefab;

    private void Start()
    {
       //Create(16, 16);
    }

    public Tile[,] Create(int x, int y)
    {
        Tile[,] tiles = new Tile[x, y];
        Vector3 position = new Vector3(0, -0.5f, 0); //-0.5f so the character keeps at 0,0,0;
        GameObject go;
      
        for (int i = 0; i < x; i++)
        {
            position.x = i;
            for (int j = 0; j < y; j++)
            {
                position.z = j;
                go = GameObject.Instantiate(tilePrefab, position, Quaternion.identity, this.transform);
                tiles[i, j].go = go;
            }
        }
        return tiles;
    }
}
