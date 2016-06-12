using UnityEngine;
using System.Collections;

/** 
 * Adjusts the box collider to size of the panel.
 * Used in UI elements for correct input identification accross screen sizes
 * */
public class ColliderToPanel : MonoBehaviour {

	// panel collider
	BoxCollider2D _collider;
	// panel transform
	RectTransform _transform;
	// current size of collider
	Vector2 size;
	
	void Start () {
		_collider = GetComponent<BoxCollider2D> ();
		_transform = GetComponent<RectTransform> ();
		setColliderSize (
			new Vector2 (_transform.rect.width, _transform.rect.height)
			);
	}
	
	void Update () {
		setColliderSize (
			new Vector2 (_transform.rect.width, _transform.rect.height)
			);
	}
	
	void setColliderSize(Vector2 size){
		if (size != _collider.size) {
			_collider.size = size;
		}
	}
	
}