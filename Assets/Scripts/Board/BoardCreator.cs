using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCreator : MonoBehaviour
{
    public GameObject tilePrefab;
    public Tile[,] tiles;

    private void Start()
    {
        Create(16, 16);
    }


    public void Create(int x, int y)
    {
        tiles = new Tile[x, y];
        Vector3 position = Vector3.zero;
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
    }
}
