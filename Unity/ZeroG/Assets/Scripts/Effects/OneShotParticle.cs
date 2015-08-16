using UnityEngine;
using System.Collections;

public class OneShotParticle : MonoBehaviour  {
	
	private IEnumerator Start()
	{
		yield return new WaitForSeconds(GetComponent<ParticleSystem>().duration);
		Destroy(gameObject); 
	}
	
}
