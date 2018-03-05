using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class project : MonoBehaviour {
	public string hit = "Enemy";
	public string avoidHit = "Nothing";

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter( Collider other ) {
		if ((other.tag != "Player") && (other.tag != avoidHit)) {
			if (other.tag == hit) {
				Destroy (other.gameObject);
			}
			Destroy (this.gameObject);
		}
	}
}