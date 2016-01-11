using UnityEngine;
using System.Collections;

public class InputHandler : MonoBehaviour {
	public delegate Vector3 TapAction(Touch t);
	public static event TapAction OnTap;

	public float tapMaxMovement = 50f;

	private Vector2 movement;
	private bool tapGestureFailed = false;

	void Update () {
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if(touch.phase == TouchPhase.Stationary)
			{
				Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
			}


			/*if (touch.phase == TouchPhase.Began) {
					movement = Vector2.zero;
			}
			else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
			{
				movement += touch.deltaPosition;
				if (movement.magnitude > tapMaxMovement)
					tapGestureFailed = true;
			}
			else 
			{
				if(!tapGestureFailed)
				{
					if (OnTap != null)
						OnTap(touch);
				}
				tapGestureFailed = false;
			}*/
		}
	}
}
