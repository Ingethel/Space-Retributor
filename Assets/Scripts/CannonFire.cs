using UnityEngine;
using System.Collections;

public class CannonFire : MonoBehaviour {
	GunnerRotation rot;
	public ParticleSystem charge;
	public ParticleSystem beam;
	BoxCollider2D beamCollider;

	void Start () {
		rot = GetComponent<GunnerRotation> ();
		beamCollider = GetComponent<BoxCollider2D> ();
		beamCollider.enabled = false;
		charge.enableEmission = false;
		beam.enableEmission = false;
		StartCoroutine (chargingBoom ());
	}


	IEnumerator chargingBoom(){
		while (true) {
			charge.enableEmission = true;
			yield return new WaitForSeconds (2);
			charge.enableEmission = false;
			rot.enabled = false;
			yield return new WaitForSeconds (2f);
			beam.enableEmission = true;
			yield return new WaitForSeconds (0.5f);
			beamCollider.enabled = true;
			yield return new WaitForSeconds (2);
			beam.enableEmission = false;
			yield return new WaitForSeconds (0.5f);
			beamCollider.enabled = false;
			yield return new WaitForSeconds (0.5f);
			rot.enabled = true;
			yield return new WaitForSeconds (5);
		}
	}

	void OnTriggerEnter2D(Collider2D c){
		if (c.CompareTag ("Player")) {
			c.GetComponentInParent<State>().getDamage(10);
		}
	}

}
