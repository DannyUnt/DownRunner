using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformPooler : MonoBehaviour {
	public static PlatformPooler current;
	public GameObject[] platform;
	public int amount = 20;
	public List<GameObject> p2;

	public List<GameObject> platforms;

	void Awake()
	{
		current = this;
	}

	void Start()
	{

		platforms = new List<GameObject> ();
		for (int i = 0; i < amount; i++) 
		{
			GameObject obj = (GameObject)Instantiate(platform[i]);
			obj.SetActive(false);
			platforms.Add(obj);
		}
	}

	public GameObject GetPooledPlatform()
	{
		p2.RemoveRange (0, p2.Count);
		for (int i = 0; i < platforms.Count; i++) 
		{
			if(!platforms[i].activeInHierarchy)
			{
				p2.Add(platforms[i]);
				//return platforms[i];
			}

		}

		if (p2.Count > 0) {
			return p2[Random.Range(0, p2.Count)];

		}
		else
			return null;


	}

}
