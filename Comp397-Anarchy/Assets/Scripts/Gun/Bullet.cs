using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody projectile;
	public Rigidbody instantiatedProjectile;
    public float speed = 10f;

    // Update is called once per frame
    void Update()
    {
    	if ( Input.GetButtonDown("Fire1") && PickupItems.equipped == true)
        {
            //makes the copy as a rigid body 
			instantiatedProjectile = Instantiate ( projectile, transform.position , transform.rotation)as Rigidbody;

			// makes the bullet move 
			instantiatedProjectile.velocity = transform.TransformDirection(new Vector3( 0f, 0f, speed * 10f));

            Destroy( instantiatedProjectile.gameObject , 10f);
        }
    }
}
