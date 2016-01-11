using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RayCastHelper : MonoBehaviour {
	public List<GameObject> rayPoints;
	public List<Ray> rays;

	public List<Ray> rayUp;
	public List<Ray> rayDown;
	public List<Ray> rayLeft;
	public List<Ray> rayRight;

	public bool collisionUp;
	public bool collisionDown;
	public bool collisionLeft;
	public bool collisionRight;

	public bool castGizmos;

	public Vector2 topLeft, topRight, bottomLeft, bottomRight;

	BoxCollider2D collider;

	void Start()
	{
		collider = GetComponent<BoxCollider2D> ();
		detectRayPoints ();
		SetRayPosition();
	
	}

	void Update()
	{
		CastRays ();
		/*if (castGizmos) {
			CastGizmos ();
		}*/

	}

	//find all Transforms with name "ray"
	public void detectRayPoints ()
	{
		foreach (Transform t in this.gameObject.transform) {
			if(t.name == "ray")
				rayPoints.Add(t.gameObject);
		}
	}

	public void SetRayPosition()
	{
		Bounds bounds = collider.bounds;
		topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		topRight = new Vector2 (bounds.max.x, bounds.max.y);
		bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
	}


	public void CastGizmos()
	{
	
	}


	public void CastRays()
	{
		rayUp = new List<Ray>();
		rayDown = new List<Ray> ();
		rayLeft = new List<Ray> ();
		rayRight = new List<Ray> ();
		

		for (int i = 0; i < rayPoints.Count; i++) {
			//check current ray UP direction
			if(rayPoints[i].GetComponent<RayDirection>().direction == RayDirection.Direction.UP)
			{
				//rayPoints[i].transform.position = topLeft;
				if(castGizmos){
					Debug.DrawLine(topLeft, new Vector2(topLeft.x, topLeft.y + rayPoints[i].GetComponent<RayDirection>().rayLenght),
					             Color.red);
				}
				rayUp.Add(new Ray(topLeft, Vector3.up));
			}


			//check current ray DOWN direction
			if(rayPoints[i].GetComponent<RayDirection>().direction == RayDirection.Direction.DOWN)
			{
				if(castGizmos) {
				Debug.DrawLine(rayPoints[i].gameObject.transform.position, new Vector3(
					rayPoints[i].gameObject.transform.position.x, 
					rayPoints[i].gameObject.transform.position.y - rayPoints[i].GetComponent<RayDirection>().rayLenght, 
					rayPoints[i].gameObject.transform.position.z), Color.red);
				}

				rayDown.Add(new Ray(new Vector3(rayPoints[i].gameObject.transform.position.x,
				                              rayPoints[i].gameObject.transform.position.y,
				                              rayPoints[i].gameObject.transform.position.z), Vector3.down));

			}

			//check current ray LEFT direction
			if(rayPoints[i].GetComponent<RayDirection>().direction == RayDirection.Direction.LEFT)
			{
				if(castGizmos) {
				Debug.DrawLine(rayPoints[i].gameObject.transform.position, new Vector3(
					rayPoints[i].gameObject.transform.position.x - rayPoints[i].GetComponent<RayDirection>().rayLenght, 
					rayPoints[i].gameObject.transform.position.y, 
					rayPoints[i].gameObject.transform.position.z), Color.red);
				}

				rayLeft.Add(new Ray(new Vector3(rayPoints[i].gameObject.transform.position.x,
				                              rayPoints[i].gameObject.transform.position.y,
				                              rayPoints[i].gameObject.transform.position.z), Vector3.left));

			}


			//check current ray RIGHT direction
			if(rayPoints[i].GetComponent<RayDirection>().direction == RayDirection.Direction.RIGHT)
			{
				if(castGizmos){
					Debug.DrawLine(rayPoints[i].gameObject.transform.position, new Vector3(
						rayPoints[i].gameObject.transform.position.x + rayPoints[i].GetComponent<RayDirection>().rayLenght, 
						rayPoints[i].gameObject.transform.position.y, 
						rayPoints[i].gameObject.transform.position.z), Color.red);
				}
				rayRight.Add(new Ray(new Vector3(rayPoints[i].gameObject.transform.position.x,
				                              rayPoints[i].gameObject.transform.position.y,
				                              rayPoints[i].gameObject.transform.position.z), Vector3.right));
			}

				

		}

		collisionUp = checkCollision (rayUp);
		collisionDown = checkCollision (rayDown);
		collisionLeft = checkCollision (rayLeft);
		collisionRight = checkCollision (rayRight);
	}

	public bool checkCollision(List<Ray> rays)
	{
		for (int i = 0; i < rays.Count; i++) {
			if (Physics.Raycast(rays[i], 3.0f))
			{
				return true;
			}
		}
		return false;
	}

}
