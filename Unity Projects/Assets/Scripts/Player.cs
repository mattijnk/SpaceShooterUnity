using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform myTransform;
	public float playerSpeed = 5;
	public static int playerlives = 3; 
	GameObject[] EnemyCount;

	//variable to reference prefeb. prefab = gameobject (reusable)
	public static int score = 0;

	float timer = 0f;

	public GameObject LazerFab;
	public GameObject EnemyFab;

	// Use this for initialization
	void Start () {
	
		myTransform = transform; 
		//Spawn point		 x  y  z
		//position to be at -3,-3,-1

		myTransform.position = new Vector3 (-13, -2, -1);

		for (int i=0; i < 3; i++ ){
			Vector3 position = new Vector3(10,Random.Range(5.5f,-3.5f),-1);
			Instantiate (EnemyFab, position, Quaternion.identity);
		}

	}

	
	// Update is called once per frame
	void Update ()
		{
	
				//Move the player left and right

				myTransform.Translate (Vector3.right * playerSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);
				myTransform.Translate (Vector3.up * playerSpeed * Input.GetAxis ("Vertical") * Time.deltaTime);

				//Make the player wrap
				//If the player is at x = -7 then it should appear. Vise versa
				//If the player object is positioned at x = -10, then the game object will
				//positioned at = -10.

				if (myTransform.position.x > 8.5f) {
						myTransform.position = new Vector3 (8.5f, myTransform.position.y, myTransform.position.z);
				} else if (myTransform.position.x < -14) {
						myTransform.position = new Vector3 (-14, myTransform.position.y, myTransform.position.z);
				}
				if (myTransform.position.y > 5.5f) {
					myTransform.position = new Vector3 (myTransform.position.x, 5.5f, myTransform.position.z);
				} 
				else if (myTransform.position.y < -3.5f) {
					myTransform.position = new Vector3 (myTransform.position.x, -3.5f, myTransform.position.z);
				}

				
				
				//Press Space Bar to fire a lazer!

				//If the player presses the spacebar, a lazer will shoot out.

				if (Input.GetKeyDown (KeyCode.Space)) {
				

						//set position for lazer

						Vector3 position = new Vector3 (myTransform.position.x + 1, myTransform.position.y, myTransform.position.z);

						//fire projectile
		
						Instantiate (LazerFab, position, Quaternion.Euler(0,0,-90));
		
				}
					if (Time.time - timer >1)

				{
					renderer.enabled = true;			
				}

		print ("Lives: " + playerlives + " score: " + score + " Current Time: " + Time.time + "    Timer to respond: " + timer);

		EnemyCount = GameObject.FindGameObjectsWithTag("Enemy") as GameObject[];
		if (EnemyCount.Length < 3){
			Vector3 position = new Vector3(10,Random.Range(5.5f,-3.5f),-1);
			Instantiate (EnemyFab, position, Quaternion.identity);
			}

		}

	//create function OnTriggerEnter(Collider collider)
		
	//if the "Enemy" collides with player
	//player will get destroyed.

	void OnTriggerEnter (Collider collider)
	{
		if (collider.gameObject.CompareTag("Enemy"))
		{
			playerlives--;
			renderer.enabled = false;
			timer = Time.time;

			if (playerlives < 1) {	
			Destroy (this.gameObject);
			}
		}
	}
}