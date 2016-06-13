using UnityEngine;
using System.Collections;

public class GunnerFire : MonoBehaviour {

	PoolManager pool;
	public GameObject bossMissile;
	public int stackSize;
	GameObject[] missileStack;
	private int index;
	GunnerRotation gunnerView;

	void Start () {
		missileStack = new GameObject[stackSize];
		for (int i = 0; i < stackSize; i++) {
			missileStack[i] = (GameObject)Instantiate(bossMissile, Vector3.zero, Quaternion.identity);
			missileStack[i].GetComponent<Rigidbody2D>().gravityScale = 0;
			missileStack[i].SetActive(false);
		}
		index = 0;
		gunnerView = GetComponent<GunnerRotation> ();
		StartCoroutine (fire ());
	}

	void FireMissiles(){
		Vector3 perpDir = Vector3.Cross (gunnerView.getDirection(), Vector3.forward);
		perpDir.Normalize ();
		perpDir *= 0.1f;

		missileStack [index].SetActive (true);
		missileStack [index].transform.position = transform.position + perpDir;
		missileStack [index].GetComponent<Rigidbody2D> ().velocity = gunnerView.getDirection()*7;

		missileStack [index+1].SetActive (true);
		missileStack [index+1].transform.position = transform.position - perpDir;
		missileStack [index+1].GetComponent<Rigidbody2D> ().velocity = gunnerView.getDirection()*7;

		index += 2;
		if (index > stackSize - 2)
			index = 0;
	}

	IEnumerator fire(){
		while (true) {
			FireMissiles();
			yield return new WaitForSeconds (1);
		}
	}

}
