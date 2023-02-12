using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int pieces;
    public int playerSprite;
    public bool[] ballunlock = new bool[9];
    public bool[] nivelunlock = new bool[3];

    public GameData(GameManager game)
    {
        pieces = game.totalPieces;
        playerSprite = game.playersprite;

        ballunlock[0] = game.ballUnlock[0];
        ballunlock[1] = game.ballUnlock[1];
        ballunlock[2] = game.ballUnlock[2];
        ballunlock[3] = game.ballUnlock[3];
        ballunlock[4] = game.ballUnlock[4];
        ballunlock[5] = game.ballUnlock[5];
        ballunlock[6] = game.ballUnlock[6];
        ballunlock[7] = game.ballUnlock[7];
        ballunlock[8] = game.ballUnlock[8];

        nivelunlock[0] = game.nivelUnlock[0];
        nivelunlock[1] = game.nivelUnlock[1];
        nivelunlock[2] = game.nivelUnlock[2];
    }
}
