using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * Animation for UI buttons
 * "Animation" is done by changing text and UI border colors when pressed
 * */
public class PanelPressed : MonoBehaviour {

	Text _text;
	Image _image;
	bool pressed;
	Color _colorPressed = new Color(71f/255f, 93f/255f, 255f/255f, 1f);
	Color _colorNotPressed = new Color(1f, 1f, 1f, 1f);
	Color _colorNotPressedAlpha = new Color(1f, 1f, 1f, 0f);

	void Start () {
		_text = GetComponentInChildren<Text> ();
		_image = GetComponent<Image> ();
	}

	/**
	 * Sets <pressed> status for button
	 * */
	public void setPressed(bool p){
		pressed = p;
		if (pressed)
			buttonPressed ();
		else
			buttonNotPressed ();
	}

	void buttonPressed(){
		_text.color = _colorPressed;
		_image.color = _colorPressed;
	}

	void buttonNotPressed(){
		_text.color = _colorNotPressed;
		_image.color = _colorNotPressedAlpha;
	}
}
