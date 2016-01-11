using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {
	public GameObject Menu;
	private Animator anim;
	public GameObject ScoreLabel;
	public Text score;

	private static UIManager _instance;
	
	public static UIManager Instance
	{
		get {
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<UIManager>();
				
				if (_instance == null)
				{
					GameObject container = new GameObject("UIManager");
					_instance = container.AddComponent<UIManager>();
				}
			}
			
			return _instance;
		}
	}

	void Start()
	{
		anim = Menu.GetComponent<Animator> ();
		anim.enabled = false;
	}

	public void UpdateScore(float distance)
	{
		score = ScoreLabel.GetComponent<Text> ();
		score.text = Mathf.RoundToInt(distance).ToString ();
	}
	
	public void RestartGame()
	{
		anim.Play ("SlideUpMenu");
		Application.LoadLevel ("test2");
	}

	public void GameOver()
	{
		anim.enabled = true;
		anim.Play ("SlideDownMenu");
	}
}
