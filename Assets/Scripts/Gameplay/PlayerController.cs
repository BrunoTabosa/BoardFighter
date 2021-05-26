using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public Character character;

    public Tile currentTile;

    public int remaingActions;
    public int maximumActionsPerTurn;
    public int team = -1;
    public int dicesToRoll = 3;
    
    public int health;
    public int attack;

    public void Init(Character characterPrefab, int newTeam)
    {
        character = Instantiate(characterPrefab, this.transform.position, Quaternion.identity);
        team = newTeam;
        remaingActions = maximumActionsPerTurn;
    }

    public void MoveTo(Tile tile)
    {
        currentTile = tile;
        remaingActions--;
        character.FaceAndMove(tile.x, tile.y);
    }

    public void SetInBattle(bool value)
    {
        character.SetBattleMode(value);
    }
}
