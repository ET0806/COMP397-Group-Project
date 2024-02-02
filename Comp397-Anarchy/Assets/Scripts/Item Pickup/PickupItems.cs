using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItems : MonoBehaviour
{
    public GameObject gunName;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, cam, gunContainer;

    public float PickupRange;
    public float dropForwardForce, dropUpwardForce;

    public static bool equipped;
    public static bool slotFull;

    

    public void Start(){
        if(!equipped){
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        
        if(equipped){
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }

    }

    private void Update(){
        Vector3 distanceToPlayer = player.position - transform.position;

        //picks up the gun 
        if (!equipped && distanceToPlayer.magnitude <= PickupRange && Input.GetKeyDown(KeyCode.E) && !slotFull) {
            pickup();
        }

        //drops gun
        if(equipped && Input.GetKeyDown(KeyCode.Q)){
            drop();
        }
    }


    private void pickup(){
        equipped = true;
        slotFull = true;
        
        //make rigidbody kinematic 
        rb.isKinematic = true; 
        coll.isTrigger = true;
        
        //makes the waepon a child of the guncontainer 
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        if (gunName.name == "Gun"){
            transform.localScale = new Vector3(0.2f, 0.2f, 0.8f);
        }

    }

    private void drop(){
        equipped = false;
        slotFull = false;
        
        //make the item not a child of the parent anymore 
        transform.SetParent(null);

        //make rigidbody not kinematic and collider to normal 
        rb.isKinematic = false; 
        coll.isTrigger = false;

        //gun carries momentum of player 
        rb.velocity = player.GetComponent<Rigidbody>().velocity;

        //add force to throw gun 
        rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);
    }
}
