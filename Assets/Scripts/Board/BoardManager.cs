using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public BoardCreator boardCreator;
    Tile[,] tiles;

    // Start is called before the first frame update
    void Start()
    {
        tiles = boardCreator.Create(16, 16);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Tile GetTileAt(int x, int y)
    {
        return tiles[x, y];
    }
}
