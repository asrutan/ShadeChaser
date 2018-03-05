using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartBehavior : MonoBehaviour {
    public GameObject GameRules;
    private GameVars gameVarsScript;

    public GameObject Player;
    
    void Awake()
    {
        gameVarsScript = GameRules.GetComponent<GameVars>();
    }

    void Update()
    {
        if (gameVarsScript.GetPlayerIsDead() && gameVarsScript.GetPlayerState() < 5)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        Instantiate(Player);
    }
}
