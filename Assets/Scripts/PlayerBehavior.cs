using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {
	private Vector3 moveDirection = Vector3.zero;
	private Vector3 rotateDirection = Vector3.zero;
	private Vector3 forward = Vector3.zero;
	private Vector3 right = Vector3.zero;
    private GameObject spawnPoint;
    private GameObject gameRules;
    private GameVars gameVarsScript;
    private GameObject playerMeshObj;
    private LightDamage[] LightZonesScripts = new LightDamage[22];
    private GameObject DamageZone;
    //private GameObject

    public Material[] materials;

    public float speed = 3.0F;
	public float jumpSpeed = 4.0F;
	public float gravity = 9.8F;
    
	public GameObject prefab;
	public Transform projectileSpawnPoint;
	public GameObject player;
    public GameObject[] LightZones = new GameObject[22];

	public float fireSpeed = 1000f;

    public int CurrentState = 0;
    /*
    void Awake()
    {
        gameRules = GameObject.Find("GameRules");
        gameVarsScript = gameRules.GetComponent<GameVars>();
        CurrentState = gameVarsScript.GetPlayerState();

        playerMeshObj = this.transform.GetChild(0).gameObject; //Get child "player" from this gameobject
        playerMeshObj.GetComponent<Renderer>().material = materials[CurrentState];

        spawnPoint = GameObject.Find("PlayerStart");
        transform.position = spawnPoint.transform.position;

        for(int i = 0; i < LightZones.Length; i++)
        {
            LightZonesScripts[i] = LightZones[i].GetComponent<LightDamage>();
            LightZonesScripts[i].SetPlayer(gameObject);
        }

        gameVarsScript.SetPlayerIsDead(false);
    }
    */
    void Start()
    {
        gameRules = GameObject.Find("GameRules");
        gameVarsScript = gameRules.GetComponent<GameVars>();
        CurrentState = gameVarsScript.GetPlayerState();

        playerMeshObj = transform.GetChild(0).gameObject; //Get child "player" from this gameobject
        playerMeshObj.GetComponent<Renderer>().material = materials[CurrentState];

        spawnPoint = GameObject.Find("PlayerStart");
        transform.position = spawnPoint.transform.position;

        DamageZone = GameObject.Find("DamageZone");
        for (int i = 0; i < 22; i++)
        {
            print(i);
            LightZones[i] = DamageZone.transform.GetChild(i).gameObject;
            LightZonesScripts[i] = LightZones[i].GetComponent<LightDamage>();
            LightZonesScripts[i].SetPlayer(gameObject);
        }

        gameVarsScript.SetPlayerIsDead(false);
    }

    // Update is called once per frame
    void Update () {
		CharacterController controller = GetComponent<CharacterController>();
		moveDirection.x = Input.GetAxis("Horizontal") * speed;
		if (controller.isGrounded) {
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		moveDirection.y -= gravity * Time.deltaTime;
		moveDirection.z = Input.GetAxis("Vertical") * speed;
		moveDirection = transform.TransformDirection(moveDirection);
		controller.Move(moveDirection * Time.deltaTime);

		if (Input.GetButtonDown ("Fire1")) {
			GameObject projectile = Instantiate (prefab, projectileSpawnPoint.position, Quaternion.identity);
			Rigidbody rb = projectile.GetComponent<Rigidbody>();
			rb.AddForce (projectileSpawnPoint.transform.forward * /*1000f*/fireSpeed);
		}
		forward = transform.forward;
		right.x = forward.z;
		right.y = 0f;
		right.z = -forward.x;
		var horiz = Input.GetAxis("Horizontal");
		var vert = Input.GetAxis ("Vertical");
		var dir = horiz * right + vert * forward;
		rotateDirection = Vector3.RotateTowards (rotateDirection, dir, 200 * Mathf.Deg2Rad * Time.deltaTime, 1000);
		if (dir != Vector3.zero) {
			player.transform.rotation = Quaternion.LookRotation (rotateDirection);
		}
	}

    public void Die()
    {
        gameVarsScript.IncPlayerState();
        gameVarsScript.SetPlayerIsDead(true);
        Destroy(gameObject);
    }
}