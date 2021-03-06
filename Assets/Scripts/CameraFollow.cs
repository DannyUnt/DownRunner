﻿using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public GameObject target;
	private Transform _t;
	
	void Start () {
		_t = target.transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(_t)
			transform.position = new Vector3 (transform.position.x, _t.position.y, transform.position.z);
	}
}
