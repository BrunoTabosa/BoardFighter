using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    int diceMax = 6;

    public int Battle(PlayerController playerA, PlayerController playerB)
    {
        int[] playerARolls = RollDices(playerA.dicesToRoll, diceMax);
        print($"playerA Rolls: {playerARolls[0]}, {playerARolls[1]}, {playerARolls[2]}");
        int[] playerBRolls = RollDices(playerB.dicesToRoll, diceMax);
        print($"playerB Rolls: {playerBRolls[0]}, {playerBRolls[1]}, {playerBRolls[2]}");

        return CompareRolls(playerARolls, playerBRolls);
    }

    int[] RollDices(int amount, int dice)
    {
        int[] results = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            results[i] = Random.Range(1, dice);
        }
        System.Array.Sort(results);
        System.Array.Reverse(results);
        return results;
    }

    //Player A is the current turn, have the draw advantage
    //1 player a
    //0 draw
    //-1 player b
    int CompareRolls(int[] playerA, int[] playerB)
    {
        int result = 0;
        for (int i = 0; i < 3; i++)
        {
            if(playerA[i] >= playerB[i])
            {
                result++;
            }
            else
            {
                result--;
            }
        }

        result = Mathf.Clamp(result, -1, 1);
        print($"Compare results: {result}");

        return result;
    }
}
