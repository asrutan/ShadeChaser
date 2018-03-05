using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDamage : MonoBehaviour {

    private GameObject Player;
    private PlayerBehavior playerScript;

    private GameObject gameRules;
    private GameVars gameVarsScript;

    private bool deadCheck = false;

    // Use this for initialization
    void Start () {
        gameRules = GameObject.Find("GameRules");
        gameVarsScript = gameRules.GetComponent<GameVars>();

        Player = GameObject.FindWithTag("Player");
        playerScript = Player.GetComponent<PlayerBehavior>();
    }

    /*
    void Update()
    {
        print(deadCheck);
        //This segment waits for the new player instance to be spawned and then grabs its script.

        if (!deadCheck)
        {
            if (gameVarsScript.GetPlayerIsDead())
            {
                deadCheck = true;
            }
        }
        while (deadCheck)
        {
            if (!gameVarsScript.GetPlayerIsDead())
            {
                deadCheck = false;
                Player = GameObject.FindWithTag("Player");
                playerScript = Player.GetComponent<PlayerBehavior>();
            }
        }
    }*/
	
   public void SetPlayer(GameObject newPlayer)
    {
        Player = newPlayer;
        playerScript = Player.GetComponent<PlayerBehavior>();
    }

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")) {
            playerScript.Die();
            Player = null;
            playerScript = null;
		}
	}

}

	