using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject PlayerArrow;
	public float xInput;
	public float yInput;
	Rigidbody2D playerRigidBody;
	float impulseRate;
	PlayerClass myInfo;

	// Conditional Checks
	public bool canJump;
	bool didJump;
	public bool grounded;
	public bool hasBall;
	public GameObject theBall;

	// Use this for initialization
	void Start () {
	
		playerRigidBody = GetComponent<Rigidbody2D> ();
		myInfo = GetComponent<PlayerClass> ();
		theBall = null;

		canJump = true;
		didJump = false;
		grounded = false;
		hasBall = false;
		impulseRate = 15f;
	}
	
	// Update is called once per frame
	void Update () {
	
		calculateArrowAngle ();

		if (didJump) {
			if(hasBall){
				theBall.GetComponent<Script_GameBall>().pushBall(xInput, yInput);

			}else{
				Jump();
			}
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
		grounded = false;

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
			grounded = true;
		}

	}

	void OnCollisionExit2D(Collision2D other){
		
		if (other.gameObject.tag == "Environment") {
			canJump = false;
			grounded = false;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other){

		PlayerController otherInfo;
		otherInfo = other.gameObject.GetComponent<PlayerController> ();

		if (other.gameObject.tag == "Player" && grounded) {
			playerRigidBody.AddForce (new Vector2(otherInfo.xInput * -1 *impulseRate, otherInfo.yInput * -1 * impulseRate), ForceMode2D.Impulse);
		}
		else if (other.gameObject.tag == "Player" && !grounded && !otherInfo.grounded) {
			playerRigidBody.AddForce (new Vector2(xInput * -2 *impulseRate, yInput * -2 * impulseRate), ForceMode2D.Impulse);
			Debug.Log("Hey Player: " + myInfo.playerNum);
		}

		if (other.gameObject.tag == "Ball") {

			//theBall.transform.parent = this.gameObject.transform.FindChild("Player Sprite").transform;
			BallGrab(other.gameObject);
		}
	}

	void BallGrab(GameObject ball){

		theBall = ball;
		//theBall.GetComponent<Rigidbody2D> ().isKinematic = true;
		theBall.transform.parent = this.gameObject.transform;
		theBall.transform.localPosition = new Vector3(0, 0, 0);
		hasBall = true;

	}

	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.tag == "Ball") {
			theBall = null;
			hasBall = false;
			didJump = false;
		}

	}

}
