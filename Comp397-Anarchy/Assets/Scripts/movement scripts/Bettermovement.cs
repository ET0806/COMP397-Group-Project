using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bettermovement : MonoBehaviour
{
	public CharacterController controller;
	public float speed = 6f;
	public float turnSmoothTime = 0.1f;
	float turnSmoothVelocity;
	public bool isTouchingGround;
	private bool groundedPlayer;
	public Transform cam;

	//legit only for jumping 
	private Vector3 playerVelocity;
	public float jumpHeight = 1f;
	public float gravityValue = -9.8f;
	public float jumpValue = 0f;
		
    // Start is called before the first frame update
    void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    	controller = GetComponent<CharacterController>();
		isTouchingGround = false;
    }

    // Update is called once per frame
    void Update()
    {
	
	//for jumping and gravity 
	if(isTouchingGround){
		groundedPlayer = true;
		jumpValue = 0f;
		gravityValue = -9.81f;
	}else{
		groundedPlayer = false;
	}

	if (groundedPlayer && playerVelocity.y < 0)
     {
        playerVelocity.y = 0f;
     }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && (groundedPlayer == true) || Input.GetButtonDown("Jump") && jumpValue < 2)
        {
		if (jumpValue == 1f){
		gravityValue = gravityValue - 25f;
		playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue) * 2f;
		}else{
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}
		jumpValue = jumpValue + 1;
		isTouchingGround = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

	//for turning and making it look nice 
    	float horizontal = Input.GetAxisRaw("Horizontal");
		float vertical = Input.GetAxisRaw("Vertical");
		Vector3 direction = new Vector3(horizontal, 0f, vertical);
		transform.rotation = Quaternion.Euler(0f, cam.eulerAngles.y , 0f);

		if(direction.magnitude >= 0.1f){
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
		Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
			controller.Move(moveDir.normalized * speed * Time.deltaTime);
		}
    }
	void OnTriggerEnter(Collider ground){
		isTouchingGround = true;
	}
	void OnTriggerExit(Collider ground){
		isTouchingGround = false;
	}
}

