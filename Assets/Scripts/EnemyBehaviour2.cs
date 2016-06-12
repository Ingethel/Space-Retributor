using UnityEngine;
using System.Collections;

/**
 * Enemy behaviour level 2
 * Periocically locks the target and follows him
 * */
public class EnemyBehaviour2 : IEnemyBehaviour {

	// lock target variables
	float lockFrequency = 0.5f;
	float lastLock = -2.0f;
	float lockInterval = 2f;
	int lockFires = 3;
	Vector3 lockPos;
	int fired = 0;
	int state = 0;

	/**
	 * lock target mechanic to follow player
	 * AI behaviour Level 2
	 * */
	public override void behave(){
		if(state == 0){
			float dist = Mathf.Abs(transform.position.x - target.GetComponent<Transform>().position.x);
			if( dist < 0.1f){
				lockPos = transform.position;
				gravity.enabled = false;
				// disable rigid body to allow different movement
				body.Sleep();
				lockPos = transform.position;
				state = 1;
			} else{
				Fire(frequency);
			}
		} else if (state == 1){
			// lock time based on shots fired
			if(LockTarget()){
				fired++;
			}
			if(fired >= lockFires){
				// re-enable rigid body for basic movement
				body.WakeUp();
				gravity.enabled = true;
				state = 2;
				lastLock = Time.time;
			}
		} else if (state == 2){
			Fire(frequency);
			// check for lock interval
			if(Time.time - lastLock > lockInterval){
				state = 0;
			}
		}
	}
	
	bool LockTarget(){
		transform.position = Vector2.Lerp(transform.position, new Vector3(target.GetComponent<Transform>().position.x, lockPos.y, lockPos.z), 0.4f);
		return Fire (lockFrequency);
	}
}
