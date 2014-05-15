using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private Transform myTransform;

	public int projectileSpeed = 7;

	// Use this for initialization
	void Start () {
		myTransform = transform;
	}
	
	// Update is called once per frame
	void Update ()
		{
	
				//make the lazer shoot out and go up!

				//gameobject = lazer = shoot up

				myTransform.Translate (Vector3.up * projectileSpeed * Time.deltaTime);
	
				//Destroy the object if the y value is greater than 8
				if (myTransform.position.y > 8) {
						DestroyObject(gameObject);
		 
				}
		}

}
