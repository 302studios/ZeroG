using UnityEngine;
using System.Collections;

public class IntroAnimation : MonoBehaviour {




	public SpriteRenderer f1;
	public SpriteRenderer f2;
	public SpriteRenderer f3;
	public SpriteRenderer f4;
	
	private float timer;




	void Start () 
	{
		timer = 0;
	}
	

	void Update () 
	{
		timer += Time.deltaTime;

		if(timer >= 3f)//smoke
			f2.color = new Vector4(f2.color.r, f2.color.g, f2.color.b, (f2.color.a + 1.2f * Time.deltaTime));

	//	if(timer >= 8f)//white
		//	f4.color = new Vector4(f4.color.r, f4.color.g, f4.color.b, (f4.color.a + 1f * Time.deltaTime));

		if(timer >= 10f)//last
		{
			f3.color = new Vector4(f3.color.r, f3.color.g, f3.color.b, (f3.color.a + 1.2f * Time.deltaTime));
		}

		//if(timer > 13f)
			//Application.LoadLevel("Master");
			
	}


}
