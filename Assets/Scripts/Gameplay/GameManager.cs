using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController controllerPrefab;
    public Character[] characterPrefab;
    public BoardManager boardManager;
    public BattleManager battleManager;

    PlayerController[] playerControllers;
    PlayerController currentPlayer;
    int currentPlayerId = 0;

    public static Action OnMoveComplete; 

    //Tile Select
    public LayerMask layer;

    Camera camera;
    Ray ray;
    RaycastHit hitData;
    GameObject selectedObject;
    //--

    //Turn State Machine
    StateMachine stateMachine;


    //-----

    public void Start()
    {
        InitCharacters(2);
        camera = Camera.main;
        OnMoveComplete += OnMoveFinished;

        stateMachine = new StateMachine();
        SetupPlayerTurn(0);
    }

    private void Update()
    {
        HandleInput();

        stateMachine.currentState?.Update();
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

        playerControllers[1] = Instantiate(controllerPrefab, new Vector3(4, 0, 4), Quaternion.identity);
        playerControllers[1].Init(characterPrefab[0], 2);
        playerControllers[1].currentTile = boardManager.tiles[4, 4];
        boardManager.SetTileTeam(4, 4, 2);
    }

    void HandleInput()
    {
        ray = camera.ScreenPointToRay(Input.mousePosition);
        
        //Debug.DrawRay(ray.origin, ray.direction * 500, Color.red);

        if (Physics.Raycast(ray, out hitData, 500, layer) && Input.GetMouseButtonDown(0))
        {
            selectedObject = hitData.transform.gameObject;
            //selectedObject.GetComponent<Renderer>().material.color = Color.green;
            int x = (int)selectedObject.transform.position.x;
            int y = (int)selectedObject.transform.position.z;

            var selectedTile = boardManager.GetTileAt(x, y);
            if(CanMove(currentPlayer, currentPlayer.currentTile, selectedTile) && currentPlayer.remaingActions > 0)
            {
                boardManager.MoveCharacter(currentPlayer.currentTile, selectedTile, currentPlayer);
                currentPlayer.MoveTo(selectedTile);
            }
        }
    }

    void OnMoveFinished()
    {
        if(CheckIfEnemiesNearby(currentPlayer.currentTile, currentPlayer.team))
        {
            //refactor for only nearby characters
            foreach (var c in playerControllers)
            {
                c.SetInBattle(true);
            }
            print("move finisehd with enemy nearby");
            battleManager.Battle(playerControllers[0], playerControllers[1]);
            
        }
        else
        {
            //refactor for only nearby characters
            foreach (var c in playerControllers)
            {
                c.SetInBattle(false);
            }
        }
        
        if(currentPlayer.remaingActions <= 0)
        {
            OnEndPlayerTurn();
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

    public void OnEndPlayerTurn()
    {
        print("OnEndPlayerTurn");
        //Goes to next player or to first
        currentPlayerId = currentPlayerId + 1 >= playerControllers.Length ? 0 : currentPlayerId + 1;
        SetupPlayerTurn(currentPlayerId);
    }
    
    void SetupPlayerTurn(int id)
    {
        currentPlayerId = id;
        currentPlayer = playerControllers[currentPlayerId];
        currentPlayer.remaingActions = currentPlayer.maximumActionsPerTurn;
        stateMachine.SetState(new PlayerTurnState(currentPlayer, this));
    }
}

