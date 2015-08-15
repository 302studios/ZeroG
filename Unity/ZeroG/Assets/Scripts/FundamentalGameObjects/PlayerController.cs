using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject PlayerArrow;
	float xInput;
	float yInput;
	Rigidbody2D playerRigidBody;
	float impulseRate;
	PlayerClass myInfo;

	// Conditional Checks
	bool canJump;
	bool didJump;

	// Use this for initialization
	void Start () {
	
		playerRigidBody = GetComponent<Rigidbody2D> ();
		myInfo = GetComponent<PlayerClass> ();

		canJump = true;
		didJump = false;
		impulseRate = 20f;
	}
	
	// Update is called once per frame
	void Update () {
	
		calculateArrowAngle ();

		if (didJump) {
			Jump();
		}

	}

	void calculateArrowAngle(){

		float arrowDegree;

		ControllerInput ();
	
		arrowDegree = Mathf.Atan2(yInput,xInput) * Mathf.Rad2Deg;


		PlayerArrow.transform.eulerAngles = new Vector3(0, 0, arrowDegree);

	}

	void Jump() {

		didJump = false;
		canJump = false;

		playerRigidBody.AddForce (new Vector2(xInput * impulseRate, yInput * impulseRate), ForceMode2D.Impulse); 

	}
	
	void ControllerInput () {

		switch (myInfo.playerNum) {

		case 0:
			xInput = Input.GetAxis ("Horiz_P1");
			yInput = Input.GetAxis ("Vert_P1");
			if (Input.GetButtonUp ("Push_P1") && canJump) {
				didJump = true;
			}
			break;
		case 1:
			xInput = Input.GetAxis ("Horiz_P2");
			yInput = Input.GetAxis ("Vert_P2");
			if (Input.GetButtonUp ("Push_P2") && canJump) {
				didJump = true;
			}
			break;
		case 2:
			xInput = Input.GetAxis ("Horiz_P3");
			yInput = Input.GetAxis ("Vert_P3");
			if (Input.GetButtonUp ("Push_P3") && canJump) {
				didJump = true;
			}
			break;
		case 3:
			xInput = Input.GetAxis ("Horiz_P4");
			yInput = Input.GetAxis ("Vert_P4");
			if (Input.GetButtonUp ("Push_P4") && canJump) {
				didJump = true;
			}
			break;

		}

		if (xInput == 0 && yInput == 0) {
			xInput = 1;
		}


		//Debug.Log ("Horizontal Axis: " + xInput);
		//Debug.Log ("Vertical Axis: " + yInput);
	}

	void OnCollisionStay2D(Collision2D other){

		if (other.gameObject.tag == "Environment") {
			canJump = true;
		}

	}

	void OnCollisionEnter2D(Collision2D other){
		
		if (other.gameObject.tag == "Player") {
			playerRigidBody.AddForce (new Vector2(xInput * -1 *impulseRate, yInput * -1 * impulseRate), ForceMode2D.Impulse);
		}
		
	}

}
