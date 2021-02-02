using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public BoardCreator boardCreator;
    public Tile[,] tiles;

    // Start is called before the first frame update
    void Awake()
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

    public void SetTileTeam(int x, int y, int playerTeam)
    {
        tiles[x, y].playerTeam = playerTeam;
    }

    public List<Tile> GetAdjacentTiles(Tile tile)
    {
        List<Tile> adjTiles = new List<Tile>();
       
        //West Tile
        if(tile.x + 1 < tiles.GetLength(0))
        {
            adjTiles.Add(tiles[tile.x + 1, tile.y]);
        }
        //East tile
        if (tile.x - 1 > 0)
        {
            adjTiles.Add(tiles[tile.x - 1, tile.y]);
        }
        //North tile
        if (tile.y + 1 < tiles.GetLength(0))
        {
            adjTiles.Add(tiles[tile.x, tile.y + 1]);
        }
        //South tile
        if (tile.y - 1 > 0)
        {
            adjTiles.Add(tiles[tile.x, tile.y - 1]);
        }

        return adjTiles;
    }
}
