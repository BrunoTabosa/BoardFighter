using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [HideInInspector]
    public Character character;


    public int remaingActions;
    public int maximumActionsPerTurn = 3;

    public void Init(Character characterPrefab)
    {
        character = Instantiate(characterPrefab, new Vector3(5, 0, 5), Quaternion.identity);
    }

    public void MoveTo(int x, int y)
    {
        character.FaceAndMove(x, y);
    }


}
