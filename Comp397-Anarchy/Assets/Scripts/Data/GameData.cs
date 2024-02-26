using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public Vector3 playerPosition;
    public Vector3 gun1Position;
    public Vector3 enemyPosition;

    public GameData()
    {
        playerPosition = new Vector3(-34, 3, -1);
        gun1Position = new Vector3(-31, 4, 7);
        enemyPosition = new Vector3(19, 3, -2);
    }
}
