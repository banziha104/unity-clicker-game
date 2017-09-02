using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
	static GameObject _container;
    public static GameObject Container
	{
		get { return _container; }
	}

	static DataController _instance;

	public static DataController Instance
	{
		get
		{
			if (!_instance)
			{
				_container = new GameObject();
				_container.name = "DataControll";
				_instance = _container.AddComponent(typeof(DataController)) as DataController;
				DontDestroyOnLoad(_container);
			}
			return _instance;
		}
	}
	// Use this for initialization
	public string gameDataProjectFilePath = "/game.json";

	public GameData GameData;
	public int Gold = 0;
	
	public int GoldPerSec = 1;

	public int CollectGoldLevel = 1;

	public StatData statData;

	public StatData GetStatList()
	{
		if (statData == null)
		{
			LoadStatData();
		}
		return statData;
	}

	public void LoadStatData()
	{
		TextAsset statJson = Resources.Load("MetaData/Stat") as TextAsset;
		statData = JsonUtility.FromJson<StatData>(statJson.text);
	}

	public void LoadGameData()
	{
		string filePath = Application.persistentDataPath + gameDataProjectFilePath;
		
	}
}
