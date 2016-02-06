using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject player;
	private bool isDead;
	private bool pause;
	Vector3 startPosition;
	Vector3 offsetY = new Vector3(0,270,0);

	private static GameController _instance;

	public static GameController Instance 
	{
		get {
			if(_instance == null) {
				_instance = GameObject.FindObjectOfType<GameController>();
				if(_instance == null)
				{
					GameObject temp = new GameObject("GameController");
					_instance = temp.AddComponent<GameController>();
				}
			}
			return _instance;
		}
	}

	public bool Pause {
		get {
			return pause;
		}
		set{
			pause = value;
			if(pause)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;

		}
	}

	public void GameOver()
	{
		isDead = true;
		StopCoroutine ("PositionPlatform");
		UIManager.Instance.GameOver ();
	}
	
	void Start () {
		UIManager.Instance.UpdateScore (25);
		SpawnPlayer ();
		StartGame ();
	}

	public void SpawnPlayer()
	{
		startPosition = player.transform.position;
	}

	public void StartGame()
	{
		isDead = false;
		StartCoroutine ("PositionPlatform");
	}
			
	IEnumerator PositionPlatform()
	{
		//Генерируем новую платформу каждые 2 секунды
		while (true) {
			yield return new WaitForSeconds (2.0f);
			GameObject platform = PlatformPooler.current.GetPooledPlatform(); // достаем свободную платформу из пула
			this.transform.position -= offsetY; //меняем позицию объекта, по координатам которого выставляется платформа
			platform.transform.position = this.transform.position; //меняем позицию платформы
			platform.SetActive(true);
		}
	}

}
