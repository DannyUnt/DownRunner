using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {
	private float startY;
	private float duration = 2.0f;
	// Use this for initialization
	void Start () {
		startY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		float newY = startY + (startY + Mathf.Cos (Time.time / duration * 8)) / 4;
		transform.position = new Vector2(transform.position.x, newY);
	}
}
