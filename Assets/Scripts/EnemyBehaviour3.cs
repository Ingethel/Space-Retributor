using UnityEngine;
using System.Collections;

/**
 * Enemy behaviour level 3
 * Periodically enables evasion manouvers when in danger
 * */
public class EnemyBehaviour3 : IEnemyBehaviour {

	// evasion variables - behaviour level 3
	float evasionInterval = 3f;
	float lastEvasion = -3f;
	bool evading = false;
	bool startEvasion = false;
	float posX;

	public override void behave(){
		Fire (frequency);
		if(startEvasion){
			Evade();
		}
	}

	public void StartEvasion(){
		startEvasion = true;
	}
	
	/**
	 * evasion mechanic when under fire
	 * AI behaviour Level3
	 * */
	void Evade(){
		if (!evading) {
			if(Time.time - lastEvasion > evasionInterval){
				evading = true;
				gravity.enabled = false;
				// disable rigid body to allow different movement
				body.Sleep ();
				posX = Random.Range (1.5f, 2);
				posX = Random.value < 0.5f ? transform.position.x + posX : transform.position.x - posX;
				lastEvasion = Time.time;
			}
		} else {
			transform.position = Vector2.Lerp(transform.position, new Vector3(posX, transform.position.y, transform.position.z), 0.1f);
		}
		if(Mathf.Abs(transform.position.x - posX) < 0.1){
			// re-enable rigid body for basic movement
			body.WakeUp();
			gravity.enabled = true;
			evading = false;
			startEvasion = false;
		}
	}
}
