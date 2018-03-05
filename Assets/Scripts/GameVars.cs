using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVars : MonoBehaviour {
    //private int playerSpawnState = 0;
    //private bool playerIsDead = false;

    public int playerSpawnState = 0;
    public bool playerIsDead = false;

    //********
    //Setters
    //********
    public void IncPlayerState()
    {
        playerSpawnState++;
    }

    public void SetPlayerIsDead(bool dead)
    {
        playerIsDead = dead;
    }

    //********
    //Getters
    //********
    public int GetPlayerState()
    {
       return playerSpawnState;
    }

    public bool GetPlayerIsDead()
    {
        return playerIsDead;
    }
}
