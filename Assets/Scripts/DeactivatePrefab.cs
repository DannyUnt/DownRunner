using UnityEngine;
using System.Collections;

public class DeactivatePrefab : MonoBehaviour {
	GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update()
	{
		if (player.transform.position.y + 270 <= this.gameObject.transform.position.y)		
			this.gameObject.SetActive (false);
	}

}
