using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
	private static GameObject _container;

	public static GameObject Container
	{
		get { return _container; }
	}

	private static DataController _instance;

	public static DataController Instance
	{
		get
		{
			if (!_instance)
			{
				_container = new GameObject();
				_container.name = "DataControll";
				_instance = _container.AddComponent(typeof(DataController)) as DataController;
			}
			return _instance;
		}
	}
	// Use this for initialization
	public int Gold = 0;
	
	public int GoldPerSec = 1;
	

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
