using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

    public GameObject Player;
    public GameObject GameRules;

	// Use this for initialization
	void Awake () {
        Instantiate(Player);
	}
}
