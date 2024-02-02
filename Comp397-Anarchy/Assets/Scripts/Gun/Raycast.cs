using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
	public Rigidbody projectile;
	public float speed = 10f;
	public Rigidbody instantiatedProjectile;


    // Update is called once per frame
    void Update()
    {
    	if ( Input.GetButtonDown("Fire1")){
			instantiatedProjectile = Instantiate ( projectile, transform.position , transform.rotation)as Rigidbody;

			// makes the bullet move 
			instantiatedProjectile.velocity = transform.TransformDirection(new Vector3( 0f, 0f, speed ));
			
		}
    Destroy(instantiatedProjectile, 1f);

    }
}
