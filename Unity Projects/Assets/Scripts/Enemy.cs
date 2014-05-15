using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
		
	Transform myTransform;
	public float minSpeed = 5.0f;
	public float maxSpeed = 20.0f;
	int x, y, z;
	public float currentSpeed;

	// Use this for initialization
	void Start () 
	{
		y = 14;
		z = 7;
		x = Random.Range(-14, 14);
		myTransform = transform;
		myTransform.position = new Vector3(x, y, z);
		currentSpeed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update ()
		{
			x = Random.Range (-8, 8);
			myTransform.Translate(-Vector3.up * currentSpeed * Time.deltaTime);
			if (myTransform.position.y < -9) 
			{
				myTransform.position = new Vector3 (x, y, z);
				currentSpeed = Random.Range (minSpeed, maxSpeed);
			}
		}

		
		void OnTriggerEnter (Collider collider)
		{
				//if the lazer hits the enemy
				if (collider.gameObject.CompareTag ("Lazer")) {

						//if the lazer hits the enemy
						//destroy enemy
						Destroy (this.gameObject);
				}
		}
}

		