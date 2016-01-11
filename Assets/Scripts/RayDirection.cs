using UnityEngine;
using System.Collections;

public class RayDirection : MonoBehaviour {
	public enum Direction 
	{
		LEFT,
		RIGHT,
		UP,
		DOWN
	}

	public Vector2 left, right, up, down;

	public float rayLenght;
	public Direction direction;

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(transform.position, new Vector3(.1f, .1f, .1f));
		
	}
}	