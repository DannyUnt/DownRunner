using UnityEngine;
using System.Collections;

public class DeadlyShitMover : MonoBehaviour {
	public GameObject player;
	public float deadlyShitSpeed = 5.0f;
	private Transform _t;
	private Vector3 maxDistaceToPlayer = new Vector3(0,10,0);
	
	void Start () {
		_t = player.transform;
		gameObject.transform.position = _t.position + maxDistaceToPlayer;
	}

	void Update () {
		transform.Translate (-Vector3.up * deadlyShitSpeed * Time.deltaTime);
	}
}
