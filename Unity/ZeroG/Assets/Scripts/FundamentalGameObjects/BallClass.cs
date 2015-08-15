﻿using UnityEngine;
using System.Collections;

public class BallClass : MonoBehaviour {

	public enum Type {Traditional, FloridaOrange};
	public Type type;
	private Vector2 gravForce = new Vector2();
	private Vector2 distanceBetween;
	private float distanceBetweenX;
	private float distanceBetweenY;
	private Vector2 direction = new Vector2(1,1);


	
	public float speed = 105f;

	private Vector2 expo = new Vector2();
	
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			GetComponent<Rigidbody2D>().AddForce(Vector3.left * speed, ForceMode2D.Impulse);
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			GetComponent<Rigidbody2D>().AddForce(Vector3.right * speed, ForceMode2D.Impulse);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed, ForceMode2D.Impulse);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			GetComponent<Rigidbody2D>().AddForce(Vector3.down * speed, ForceMode2D.Impulse);
		}
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Gravity Well") {
			direction = new Vector2(1,1);

			distanceBetweenX = other.transform.position.x - transform.position.x;
			distanceBetweenY = other.transform.position.y - transform.position.y;
			distanceBetween = new Vector2(distanceBetweenX, distanceBetweenY);

			expo = Vector2.Scale (distanceBetween,distanceBetween);

			expo.x  = Mathf.Pow(expo.x, -1);
			expo.y = Mathf.Pow(expo.y, -1);

			gravForce = (GetComponent<Rigidbody2D>().mass * other.GetComponent<Rigidbody2D>().mass)*expo;
			if ( distanceBetween.x < 0){
				direction.x = -1*direction.x;
			} 
			if (distanceBetween.y < 0){
				direction.y = -1*direction.y;
			}
			Debug.Log (gravForce);
		GetComponent<Rigidbody2D>().AddForce(gravForce);
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Gravity Well") {
			GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}


}
