using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyForBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
		  if(collision.gameObject.tag == "Ground"){
        Destroy(this.gameObject);
      }
      
      if(collision.gameObject.tag == "Enemy"){
        Debug.Log("hi");
        Destroy(this.gameObject);
      }
	  }
}
