using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject PlayerArrow;
	float xInput;
	float yInput;
	Rigidbody2D playerRigidBody;
	float impulseRate;

	// Conditional Checks
	bool canJump;

	// Use this for initialization
	void Start () {
	
		playerRigidBody = GetComponent<Rigidbody2D> ();
		canJump = true;
		impulseRate = 20f;
	}
	
	// Update is called once per frame
	void Update () {
	
		calculateArrowAngle ();

		if (Input.GetButtonUp ("Fire1") && canJump) {
			Jump();
		}

	}

	void calculateArrowAngle(){

		float arrowDegree;

		ControllerInput ();
		//if (yInput == 90f && xInput == 0) {
		//	arrowDegree = 90f;
		//} else {
			arrowDegree = Mathf.Atan2(yInput,xInput) * Mathf.Rad2Deg;
		//}

		//if (xInput < 0) {
		//	arrowDegree += 180f;
		//}

		PlayerArrow.transform.eulerAngles = new Vector3(0, 0, arrowDegree);
		Debug.Log ("Arrow Degree: " + arrowDegree);

	}

	void Jump() {

		ControllerInput ();

		playerRigidBody.AddForce (new Vector2(xInput * impulseRate, yInput * impulseRate), ForceMode2D.Impulse); 

	}
	
	void ControllerInput () {

		xInput = Input.GetAxis ("Horizontal");
		yInput = Input.GetAxis ("Vertical");

		if (Input.GetAxis ("Horizontal") == 0 && yInput == 0) {
			xInput = 1;
		} else {
			xInput = Input.GetAxis ("Horizontal");
		}


		//Debug.Log ("Horizontal Axis: " + xInput);
		//Debug.Log ("Vertical Axis: " + yInput);
	}
}
