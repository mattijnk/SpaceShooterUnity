using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform myTransform;

	public int playerSpeed = 5;

	//variable to reference prefeb. prefab = gameobject (reusable)

	public GameObject ProjectileFab;


	// Use this for initialization
	void Start () {
	
		myTransform = transform; 
		//Spawn point		 x  y  z
		//position to be at -3,-3,-1

		myTransform.position = new Vector3 (-3, -3, -1);


		
	}

	
	// Update is called once per frame
	void Update ()
		{
	
				//Move the player left and right

				myTransform.Translate (Vector3.right * playerSpeed * Input.GetAxis ("Horizontal") * Time.deltaTime);

				//Make the player wrap
				//If the player is at x = -7 then it should appear. Vise versa
				//If the player object is positioned at x = -10, then the game object will
				//positioned at = -10.

				if (myTransform.position.x >= 10) {
						myTransform.position = new Vector3 (-10, myTransform.position.y, myTransform.position.z);
				} else if (myTransform.position.x < -10) {
						myTransform.position = new Vector3 (10, myTransform.position.y, myTransform.position.z);
				}
	
				
				
				//Press Space Bar to fire a lazer!

				//If the player presses the spacebar, a lazer will shoot out.

				if (Input.GetKeyDown (KeyCode.Space)) {
				

						//set position for lazer

						Vector3 position = new Vector3 (myTransform.position.x, myTransform.position.y + 1, myTransform.position.z);

						//fire projectile

						Instantiate (ProjectileFab, position, Quaternion.identity);
					
		
				}
		}

	//create function OnTriggerEnter(Collider collider)
		
	//if the "Enemy" collides with player
	//player will get destroyed.

}