using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController controllerPrefab;
    public Character[] characterPrefab;
    public BoardManager boardManager;

    PlayerController[] playerControllers;

    public static Action OnMoveComplete; 

    //Tile Select
    public LayerMask layer;

    Camera camera;
    Ray ray;
    RaycastHit hitData;
    GameObject selectedObject;
    //--

    public void Start()
    {
        InitCharacters(2);
        camera = Camera.main;
        OnMoveComplete += OnMoveFinished;
    }

    private void Update()
    {
        HandleInput();
    }

    void InitCharacters(int characters)
    {
        playerControllers = new PlayerController[characters];

        //for (int i = 0; i < characters; i++)
        //{
        //    //Setup CharacterInitialPosition

        //    characterControllers[i] = Instantiate(controllerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        //    characterControllers[i].Init(characterPrefab[0]);
        //}

        playerControllers[0] = Instantiate(controllerPrefab, new Vector3(1, 0, 1), Quaternion.identity);
        playerControllers[0].Init(characterPrefab[0], 1);
        playerControllers[0].currentTile = boardManager.tiles[1, 1];
        boardManager.SetTileTeam(1, 1, 1);

        playerControllers[1] = Instantiate(controllerPrefab, new Vector3(15, 0, 15), Quaternion.identity);
        playerControllers[1].Init(characterPrefab[0], 2);
        playerControllers[1].currentTile = boardManager.tiles[15, 15];
        boardManager.SetTileTeam(15, 15, 2);
    }

    void HandleInput()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        
        //Debug.DrawRay(ray.origin, ray.direction * 500, Color.red);

        if (Physics.Raycast(ray, out hitData, 500, layer) && Input.GetMouseButtonDown(0))
        {
            selectedObject = hitData.transform.gameObject;
            //selectedObject.GetComponent<Renderer>().material.color = Color.green;


            var selectedTile = boardManager.GetTileAt((int)selectedObject.transform.position.x, (int)selectedObject.transform.position.z);
            if(CanMove(playerControllers[0], playerControllers[0].currentTile, selectedTile) && playerControllers[0].remaingActions > 0)
            {
                playerControllers[0].MoveTo(selectedTile);
                selectedTile.playerTeam = playerControllers[0].team;
            }
        }
    }

    void OnMoveFinished()
    {
        if(CheckIfEnemiesNearby(playerControllers[0].currentTile, playerControllers[0].team))
        {

        }
    }

    bool CheckIfEnemiesNearby(Tile tile, int playerTeam)
    {
        List<Tile> adjTiles = boardManager.GetAdjacentTiles(tile);

        foreach (var item in adjTiles)
        {
            if(item.playerTeam > 0 && item.playerTeam != playerTeam)
            {
                return true;
            }
        }

        return false;
    }

    bool CanMove(PlayerController player, Tile currentTile, Tile target)
    {
        if (player.remaingActions <= 0) return false;

        List<Tile> adjTiles = boardManager.GetAdjacentTiles(currentTile);
        foreach (var item in adjTiles)
        {
            if (item.x == target.x && item.y == target.y)
                return true;
        }
        return false;
    }
    
}

