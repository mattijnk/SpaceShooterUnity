using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
		
	Transform myTransform;
	public int minSpeed = 5;
	public int maxSpeed = 7;
	public int currentSpeed;

	// Use this for initialization
	void Start () 
	{
		myTransform = transform;
		currentSpeed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update ()
		{
			myTransform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
			if (myTransform.position.x < -16) 
			{
			myTransform.position = new Vector3 (10, Random.Range(55, -35) / 10, -1);
				currentSpeed = Random.Range (minSpeed, maxSpeed);
			}
		}

		
		void OnTriggerEnter (Collider collider)
		{
				//if the lazer hits the enemy
				if (collider.gameObject.CompareTag("Lazer")) {

						//if the lazer hits the enemy
						//destroy enemy
						Destroy(this.gameObject);
						
				}
			if (collider.gameObject.CompareTag("Player"))
			{
				Destroy(this.gameObject);
			}		
		}
}

		