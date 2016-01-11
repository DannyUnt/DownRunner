using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject DeadlyShit;
	public Vector2 moving = new Vector2();	
	private	float lastTouchTime;
	private float touchDelay = 0.5f;

	Animator anim = null;
	bool facingRight = false;
	
	void Awake()
	{
		anim = GetComponentInChildren<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		CheckForDeadlyShit ();

		moving.x = moving.y = 0;
		#if UNITY_EDITOR
		if (Input.GetAxis ("Horizontal") > 0) {
			moving.x = 1;
			anim.SetInteger ("AnimState", 1);
			if(facingRight)
				Flip();
		}
		
		if (Input.GetAxis ("Horizontal") < 0) {
			moving.x = -1;		
			anim.SetInteger ("AnimState", 1);
			if(!facingRight)
				Flip ();
		}
		#endif
		if (Input.touchCount > 0) {
			Touch touch = Input.touches [0];
			if (touch.phase == TouchPhase.Stationary && touch.phase != TouchPhase.Began) {
					Vector3 pos = Camera.main.ScreenToWorldPoint (touch.position);
					if(pos.x > 0) {
						moving.x = 1;
						anim.SetInteger ("AnimState", 1);
						if(facingRight)
							Flip();
					} else if(pos.x < 0)
					{
						moving.x = -1;
						anim.SetInteger ("AnimState", 1);
						if(!facingRight)
							Flip ();
					}
				}
			if(touch.phase == TouchPhase.Began)
			{
				if((Time.time - lastTouchTime) - 0.5f <= 0)
				{
					moving.y = 1;
				}
				lastTouchTime = Time.time;
			}
		}
		if(moving.x == 0)
			anim.SetInteger ("AnimState", 0);

	}


	public void CheckForDeadlyShit()
	{
		if (DeadlyShit.transform.position.y - 1 <= this.transform.position.y) 
			PlayerDied ();
	}


	public void PlayerDied()
	{
		StartCoroutine("Death");
	}

	public IEnumerator Death()
	{
		if (anim)
			anim.SetBool ("DieState", true);
		yield return new WaitForSeconds (1.0f);
		GameController.Instance.GameOver ();
	}


	void Flip()
	{
		facingRight = !facingRight;
		Vector2 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
}
